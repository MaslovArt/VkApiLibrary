using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using VkApiSDK.Requests;
using Newtonsoft.Json;
using static System.Convert;

namespace VkApiSDK.LongPoll
{
    /// <summary>
    /// Позволяет получать данные о новых событиях с помощью «длинных запросов».
    /// </summary>
    public class LongPollManager
    {
        private VkRequest _request = new VkRequest();
        private LongPollConnectionData lpData;
        private int lpMode;
        private int ts;
        private CancellationTokenSource cts;
        private SendLongPollRequest longPollRequest;

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>LongPollManager</c>
        /// </summary>
        /// <param name="aData">Данные для доступа к апи</param>
        /// <param name="lpMode">Мод
        /// <para>
        /// Сумма кодов опций из списка:
        /// <list type="modes">
        /// <item>2 — получать вложения;</item>
        /// <item>8 — возвращать расширенный набор событий;</item>
        /// <item>32 — возвращать <c>pts</c>;</item>
        /// <item>64 — в событии с кодом 8 (друг стал онлайн) возвращать дополнительные данные в поле <c>$extra</c>;</item>
        /// <item>128 — возвращать поле random_id;</item>
        /// </list>
        /// </para>
        /// </param>
        public LongPollManager(AuthData aData, int lpMode = 2)
        {
            this.lpMode = lpMode;
            AccessToken = aData.AccessToken;
        }

        #region Events

        /// <summary>
        /// Происходит когда друг становится онлайн
        /// </summary>
        public event Action<int> OnNewOnline;

        /// <summary>
        /// Происходит когда друг становится оффлайн
        /// </summary>
        public event Action<int> OnNewOffline;

        /// <summary>
        /// Происходит когда приходит новое собщение
        /// </summary>
        public event Action<int, string, Dictionary<string, string>> OnNewMessage;

        /// <summary>
        /// Происходит когда сообщение удалено
        /// </summary>
        public event Action<int, int> OnMessageDelete;

        /// <summary>
        /// Происходит когда сообщение становится прочитанным 
        /// </summary>
        public event Action<int, int> OnMessageRead;

        /// <summary>
        /// Происходит когда сообщение было отридактированно
        /// </summary>
        /// <remarks>fdd</remarks>
        public event Action<int, int, string> OnMessageEdit;

        /// <summary>
        /// Происходит когда пользователь начинает набирать сообщение
        /// </summary>
        public event Action<int> OnStartTyping;

        /// <summary>
        /// Происходит когда пользователь начинает набирать сообщение в чате
        /// </summary>
        public event Action<int, int> OnStartTypingInChat;

        /// <summary>
        /// Происходит когда изменяется информация о чате
        /// </summary>
        public event Action<int> OnChatEditing;

        #endregion

        #region Properties

        public bool IsRun { get; private set; }

        public string AccessToken { get; private set; }

        #endregion

        #region Events firing

        private void ChatEdit(object[] update)
        {
            if (OnChatEditing != null)
                OnChatEditing(ToInt32(update[1]));
        }

        private void UserTypingInChat(object[] update)
        {
            if (OnStartTypingInChat != null)
                OnStartTypingInChat(ToInt32(update[1]),
                                    ToInt32(update[2]));
        }

        private void UserTyping(object[] update)
        {
            if (OnStartTyping != null)
                OnStartTyping(ToInt32(update[1]));
        }

        private void MessageReceive(object[] update)
        {
            if (OnNewMessage != null)
            {
                if ((ToInt32(update[2]) & 2) == 2) return;

                var extraFields = lpMode > 0 ? ObjToDictinary(update[6]) : null;
                OnNewMessage(ToInt32(update[3]),
                             Convert.ToString(update[5]),
                             extraFields);
            }
            
        }

        private void FriendOffline(object[] update)
        {
            if (OnNewOffline != null)
                OnNewOffline(ToInt32(update[1]));
        }

        private void FriendOnline(object[] update)
        {
            if (OnNewOnline != null)
                OnNewOnline(ToInt32(update[1]));
        }

        private void MessageEdit(object[] update)
        {
            if (OnMessageEdit != null)
                OnMessageEdit(ToInt32(update[1]),
                                      ToInt32(update[3]),
                                      Convert.ToString(update[5]));
        }

        private void MessageRead(object[] update)
        {
            if (OnMessageRead != null)
                OnMessageRead(ToInt32(update[1]),
                                      ToInt32(update[2]));
        }

        private void MessageDelete(object[] update)
        {
            if (OnMessageDelete != null)
                OnMessageDelete(ToInt32(update[1]),
                                        ToInt32(update[3]));
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

            Task.Run(()=> {
                while(!cts.IsCancellationRequested)
                {
                    var updates = SingleRequest(ts).Result;

                    handleFailsIfNeed(updates);

                    ts = updates.Ts;
                    analysLongPollResponse(updates.Updates);
                }
            }, cts.Token);

            return true;
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
            var result = await _request.Dispath<VkResponse<LongPollConnectionData>>(
                new GetLongPollServer(
                    AccessToken: AccessToken
                ));

            lpData = result?.Response;

            longPollRequest = new SendLongPollRequest(
                Server: lpData.Server,
                Key: lpData.Key,
                Ts: lpData.Ts,
                Mode: lpMode
            );

            return lpData != null;
        }

        /// <summary>
        /// Отправляет длинный запрос
        /// </summary>
        /// <param name="ts"></param>
        /// <returns>Объект изменений</returns>
        private async Task<LongPollResponse> SingleRequest(int ts)
        {
            longPollRequest.Ts = ts;
            var result = await _request.Dispath<LongPollResponse>(longPollRequest);

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
                    case 7: MessageRead(update); break;
                    case 5: MessageEdit(update); break;
                    case 8: FriendOnline(update); break;
                    case 9: FriendOffline(update); break;
                    case 4: MessageReceive(update); break;
                    case 61: UserTyping(update); break;
                    case 62: UserTypingInChat(update); break;
                    case 51: ChatEdit(update); break;
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
        private void handleFailsIfNeed(LongPollResponse lpFails)
        {
            
        }

        private Dictionary<string, string> ObjToDictinary(object obj)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(obj));
        }

        //todo: handle longpoll fails

        //todo: fix obj to dictinary method
    }
}
