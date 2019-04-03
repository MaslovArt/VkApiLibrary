using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using VkApiSDK.Models.Response;
using Newtonsoft.Json;
using static System.Convert;
using VkApiSDK.Models.LongPoll;
using VkApiSDK.LongPoll.Methods;
using VkApiSDK.Abstraction;
using VkApiSDK.Auth;

namespace VkApiSDK.LongPoll
{
    /// <summary>
    /// Позволяет получать данные о новых событиях с помощью «длинных запросов».
    /// </summary>
    public class LongPollManager : VkApiMethodGroup
    {
        private LongPollConnectionData lpData;
        private int lpMode;
        private int ts;
        private CancellationTokenSource cts;
        private SendLongPollRequest longPollRequest;

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>LongPollManager</c>
        /// </summary>
        /// <param name="AuthData">Данные для доступа к апи</param>
        public LongPollManager(AuthData AuthData, IVkRequest VkRequest = null)
            :base(AuthData, VkRequest)
        {
            lpMode = 2;
        }

        #region Events

        /// <summary>
        /// Происходит при изменении кол-ва непрочитанных сообщений
        /// <para>handler(unreadCount)</para>
        /// </summary>
        public event Action<int> OnUnreadMessageChange;

        /// <summary>
        /// Происходит когда друг становится онлайн
        /// <para>handler(userID)</para>
        /// </summary>
        public event Action<int> OnNewOnline;

        /// <summary>
        /// Происходит когда друг становится оффлайн
        /// <para>handler(userID)</para>
        /// </summary>
        public event Action<int> OnNewOffline;

        /// <summary>
        /// Происходит когда приходит новое собщение от пользователя
        /// <para>handler(userID, text, extraFields)</para>
        /// </summary>
        public event Action<int, string, Dictionary<string, string>> OnNewMessageFromUser;

        /// <summary>
        /// Происходит когда приходит новое собщение из чата
        /// <para>handler(chatID, userID, text, extraFields)</para>
        /// </summary>
        public event Action<int, int, string, Dictionary<string, string>> OnNewMessageFromChat;

        /// <summary>
        /// Происходит когда сообщение удалено
        /// <para>handler(messageID, userID)</para>
        /// </summary>
        public event Action<int, int> OnMessageDelete;

        /// <summary>
        /// Происходит когда сообщение становится прочитанным 
        /// <para>handler(messageID, peerID)</para>
        /// </summary>
        public event Action<int, int> OnMessageRead;

        /// <summary>
        /// Происходит когда сообщение было отридактированно
        /// <para>handler(messageID, peerID, text)</para>
        /// </summary>
        public event Action<int, int, string> OnMessageEdit;

        /// <summary>
        /// Происходит когда пользователь начинает набирать сообщение
        /// <para>handler(userID)</para>
        /// </summary>
        public event Action<int> OnStartTyping;

        /// <summary>
        /// Происходит когда пользователь начинает набирать сообщение в чате
        /// <para>handler(chatID, userID)</para>
        /// </summary>
        public event Action<int, int> OnStartTypingInChat;

        /// <summary>
        /// Происходит когда изменяется информация о чате
        /// <para>handler(chatID, code)</para>
        /// </summary>
        public event Action<int, int> OnChatEditing;

        #endregion

        #region Properties

        public bool IsRun { get; private set; }

        #endregion

        #region Events firing

        private void ChatEdit(object[] update)
        {
            if (OnChatEditing == null) return;

            OnChatEditing(ToInt32(update[2]),
                          ToInt32(update[1]));
        }

        private void UserTypingInChat(object[] update)
        {
            if (OnStartTypingInChat == null) return;

            OnStartTypingInChat(ToInt32(update[1]),
                                ToInt32(update[2]));
        }

        private void UserTyping(object[] update)
        {
            if (OnStartTyping == null) return;

            OnStartTyping(ToInt32(update[1]));
        }

        private void MessageReceive(object[] update)
        {
            if (OnNewMessageFromUser == null && OnNewMessageFromChat == null) return;
            if ((ToInt32(update[2]) & 2) == 2) return;

            var extraFields = objToDictinary(update[6]);
            int peerID = ToInt32(update[3]);
            if (peerID > 2000000000)
            {
                if (extraFields.ContainsKey("source_act")) return;
                OnNewMessageFromChat(peerID,
                                     ToInt32(extraFields["from"]),
                                     Convert.ToString(update[5]),
                                     extraFields);
            }
            else
            {
                OnNewMessageFromUser(peerID,
                                     Convert.ToString(update[5]),
                                     extraFields);
            }
        }

        private void FriendOffline(object[] update)
        {
            if (OnNewOffline == null) return;

            OnNewOffline((ToInt32(update[1])) * -1);
        }

        private void FriendOnline(object[] update)
        {
            if (OnNewOnline == null) return;

            OnNewOnline((ToInt32(update[1])) * -1);
        }

        private void MessageEdit(object[] update)
        {
            if (OnMessageEdit == null) return;

            OnMessageEdit(ToInt32(update[1]),
                                  ToInt32(update[3]),
                                  Convert.ToString(update[5]));
        }

        private void MessageRead(object[] update)
        {
            if (OnMessageRead == null) return;

            OnMessageRead(ToInt32(update[1]),
                                  ToInt32(update[2]));
        }

        private void MessageDelete(object[] update)
        {
            if (OnMessageDelete == null) return;

            OnMessageDelete(ToInt32(update[1]),
                            ToInt32(update[3]));
        }

        private void UnreadCountChange(object[] update)
        {
            if (OnUnreadMessageChange == null) return;

            OnUnreadMessageChange(ToInt32(update[1]));
        }

        #endregion

        /// <summary>
        /// Запускает отслеживание новых событий
        /// </summary>
        /// <returns>true - если сервис запустился</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool StartService()
        {
            if (lpData == null)
                throw new InvalidOperationException("Отсутсвуют данные для запроса. Необходимо вызвать метод CreateConnection().");

            ts = lpData.Ts;
            cts = new CancellationTokenSource();
            IsRun = true;

            Task.Run(()=> {
                while(!cts.IsCancellationRequested)
                {
                    var updates = singleRequest(ts).Result;

                    var errCode = handleFailsIfNeed(updates);
                    if (errCode > 0) continue;

                    ts = updates.Ts;
                    analysLongPollResponse(updates.Updates);
                }
            }, cts.Token);

            return IsRun;
        }

        /// <summary>
        /// Останавливает отслеживание новых событий
        /// </summary>
        public void StopService()
        {
            if (cts != null)
                cts.Cancel();

            IsRun = false;
        }

        /// <summary>
        /// Получает информацию для отправки длинных запросов
        /// </summary>
        /// <returns>True - если соединение установлено, иначе false</returns>
        public async Task<bool> CreateConnection()
        {
            var result = await _vkRequest.Dispath<VkResponse<LongPollConnectionData>>(
                new GetLongPollServer(
                    AccessToken: AuthData.AccessToken
                ));
            lpData = result?.Response;

            if (lpData == null) return false;

            longPollRequest = new SendLongPollRequest(
                Server: lpData.Server,
                Key: lpData.Key,
                Ts: lpData.Ts,
                Mode: lpMode
            );

            return true;
        }

        /// <summary>
        /// Отправляет длинный запрос
        /// </summary>
        /// <param name="ts"></param>
        /// <returns>Объект изменений</returns>
        private async Task<LongPollResponse> singleRequest(int ts)
        {
            longPollRequest.Ts = ts;
            var result = await _vkRequest.Dispath<LongPollResponse>(longPollRequest);

            return result;
        }

        /// <summary>
        /// Вызывает события для новых изменений
        /// </summary>
        /// <param name="updates">Массив изменений</param>
        private void analysLongPollResponse(object[][] updates)
        {
            for(int i = 0; i < updates.Length; i++) { 
                int code = ToInt32(updates[i][0]);
                var update = updates[i];
                switch (code)
                {
                    case 2: MessageDelete(update); break;
                    case 4: MessageReceive(update); break;
                    case 5: MessageEdit(update); break;
                    case 7: MessageRead(update); break;
                    case 8: FriendOnline(update); break;
                    case 9: FriendOffline(update); break;
                    case 52: ChatEdit(update); break;
                    case 61: UserTyping(update); break;
                    case 62: UserTypingInChat(update); break;
                    case 80: UnreadCountChange(update); break;
                }
            }
        }

        /// <summary>
        /// Обработка ошибок
        /// </summary>
        /// <param name="lpFails"></param>
        /// <returns>
        /// <para>0 - ошибок нет</para>
        /// <para>1 — история событий устарела или была частично утеряна, приложение может получать события далее, 
        /// используя новое значение ts из ответа.</para>
        /// <para>2 — истекло время действия ключа, нужно заново получить key методом messages.getLongPollServer.</para>
        /// <para>3 — информация о пользователе утрачена, нужно запросить новые key и ts методом messages.getLongPollServer.</para>
        /// <para>4 — передан недопустимый номер версии в параметре version.</para>
        /// </returns>
        private int handleFailsIfNeed(LongPollResponse lpFails)
        {
            if (lpFails.ErrorCode == 0) return 0;

            var isOk = CreateConnection().Result;

            return lpFails.ErrorCode;
        }

        private Dictionary<string, string> objToDictinary(object obj)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(obj));
        }

        //todo: fix obj to dictinary method
    }
}
