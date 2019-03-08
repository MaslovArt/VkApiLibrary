using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkApiSDK.Friends;
using VkApiSDK.Users;
using VkApiSDK.Errors;
using VkApiSDK.Messages.Dialogs;
using VkApiSDK.Messages.Attachments;
using VkApiSDK.Messages;
using VkApiSDK.Requests;

namespace VkApiSDK
{
    public class VkClient
    {
        #region Variables

        private AuthData _authData;

        private VkRequest _vkRequest;

        #endregion

        #region Events

        public event Action<Error> OnRequestError;
        //ToDo another error events

        #endregion

        public VkClient(AuthData AuthData)
        {
            _authData = AuthData;
            _vkRequest = new VkRequest();
        }

        #region Properties

        public string AccessToken => _authData.AccessToken;

        #endregion

        #region Vk api methods

        /// <summary>
        /// Получает список диалогов
        /// </summary>
        /// <param name="count">Кол-во диалогов в запросе</param>
        /// <param name="offset">Смещение для получения данных</param>
        /// <returns></returns>
        public async Task<DialogsData> GetDialogsAsync(int count = 20, int offset = 0)
        {
            var result = await _vkRequest.Dispath<VkResponse<DialogsData>>(
                ApiMessages.GetConversations(
                    AccessToken: _authData.AccessToken,
                    Offset: offset,
                    Count: count
                ));

            return result?.Response;
        }

        /// <summary>
        /// Получает список друзей
        /// </summary>
        /// <param name="count">Кол-во друзей в запросе</param>
        /// <param name="offset">Смещение для получения данных</param>
        /// <returns>Друзей пользователя</returns>
        public async Task<FriendsData> GetFriendsAsync(int count = 5000, int offset = 0)
        {
            var result = await _vkRequest.Dispath<VkResponse<FriendsData>>(
                ApiFriends.GetFriens(
                    AccessToken: _authData.AccessToken,
                    UserID: _authData.UserID,
                    Fields: new string[]
                    {
                        ExtraField.Photo50,
                        ExtraField.IsOnline
                    },
                    Count: count,
                    Offset: offset
               ));

            return result?.Response;
        }

        /// <summary>
        /// Получает список id онлайн друзей
        /// </summary>
        /// <returns>Массив айди пользователей</returns>
        public async Task<int[]> GetOnlineFriendIDsAsync()
        {
            var result = await _vkRequest.Dispath<VkResponse<int[]>>(
                ApiFriends.GetOnlineFriends(
                    AccessToken: _authData.AccessToken,
                    UserID: _authData.UserID
                ));

            return result?.Response;
        }

        /// <summary>
        /// Получает информацию о пользователях
        /// </summary>
        /// <param name="userIDs">Набор id</param>
        /// <returns>Информацию о пользователя</returns>
        public async Task<User[]> GetUsersAsync(IEnumerable<int> userIDs, IEnumerable<string> fields = null)
        {
            var result = await _vkRequest.Dispath<VkResponse<User[]>>(
                ApiUsers.Get(
                    AccessToken: _authData.AccessToken,
                    UserIDs: userIDs,
                    Fields: fields
                ));

            return result?.Response;
        }

        /// <summary>
        /// Получает необходимые для отображения диалога данные.
        /// </summary>
        /// <param name="count">Кол-во диалогов</param>
        /// <returns>Диалоги</returns>
        public async Task<DialogRenderData[]> GetDialogsDataAsync(int count = 20, int offset = 0)
        {
            var dialogs = await GetDialogsAsync(count, offset);
            var userIDs = getUserIDs(dialogs);
            var users = await GetUsersAsync(userIDs);

            DialogRenderData[] result = GetDialogsRenderData(dialogs, users);

            return result;
        }

        /// <summary>
        /// Отправляет сообщение.
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="message">Текст</param>
        /// <returns></returns>
        public async Task<int> SendMessage(Peer peer, string message)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.SendMessage(
                    AccessToken: _authData.AccessToken,
                    PeedID: ConvertIDIfChat(peer),
                    Message: message,
                    Attachments: ""
                ));

            return result != null ? result.Response : -1;
        }

        /// <summary>
        /// Удаляет сообщение
        /// </summary>
        /// <param name="MessageIDs">ID сообщений</param>
        /// <param name="DeleteForAll">Удалять для всех</param>
        /// <returns></returns>
        public async Task<Dictionary<string, int>> DeleteMessage(IEnumerable<VkMessage> Messages, bool DeleteForAll = true)
        {
            var result = await _vkRequest.Dispath<VkResponse<Dictionary<string, int>>>(
                ApiMessages.DeleteMessage(
                    AccessToken: _authData.AccessToken,
                    MessageIDs: Messages.Select(m => m.ID),
                    DeleteForAll: DeleteForAll
                ));

            return result?.Response;
        }

        /// <summary>
        /// Редактирует сообщение
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="editMessage">Сообщение для редактирования</param>
        /// <param name="newText">Текст сообщения</param>
        /// <param name="attachments">Приложения</param>
        /// <returns></returns>
        public async Task<bool> EditMessage(Peer peer, VkMessage editMessage, string newText, string attachments = "")
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.EditMessage(
                    AccessToken: _authData.AccessToken,
                    PeedID: peer.ID,
                    MessageID: editMessage.ID,
                    Message: newText,
                    Attachments: attachments
                ));

            return result != null;
        }

        /// <summary>
        /// Закрепляет сообщение
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="pinMessage">Сообщение для закрепления</param>
        /// <returns></returns>
        public async Task<bool> PinMessage(Peer peer, VkMessage pinMessage)
        {
            var result = await _vkRequest.Dispath<VkResponse<object>>(
                ApiMessages.Pin(
                    AccessToken: _authData.AccessToken,
                    PeerID: ConvertIDIfChat(peer),
                    MessageID: pinMessage.ID
                ));

            return result == null;
        }

        /// <summary>
        /// Открепляет сообщение
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <returns></returns>
        public async Task<bool> UnpinMessage(Peer peer)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.Unpin(
                    AccessToken: _authData.AccessToken,
                    PeerID: ConvertIDIfChat(peer)
                ));

            return result == null ? false : result.Response == 1;
        }

        /// <summary>
        /// Помечает сообщения как прочитанные
        /// </summary>
        /// <param name="fromMessage">Сообщение, начиная с которого пометить как прочитанные</param>
        /// <returns></returns>
        public async Task<bool> MarkAsRead(VkMessage fromMessage)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.MarkAsRead(
                    AccessToken: _authData.AccessToken,
                    PeerID: fromMessage.PeerID,
                    StartMessageID: fromMessage.ID
                ));

            return result == null ? false : result.Response == 1;
        }

        /// <summary>
        /// Устанавливает активность набора сообщения
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="activityType">Тип набора сообщения</param>
        /// <returns></returns>
        public async Task<bool> SetActivity(Peer peer, string activityType)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.SetActivity(
                    AccessToken: _authData.AccessToken,
                    UserID: peer.ID,
                    ActivityType: activityType
                ));

            return result != null;
        }

        /// <summary>
        /// Получает историю переписки
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="count">Кол-во сообщений</param>
        /// <param name="offset">Смещение</param>
        /// <param name="startMessageID">Начиная с какого получать</param>
        /// <param name="fields">Дополнительные поля</param>
        /// <returns></returns>
        public async Task<DialogHistoryData> GetDialogHistory(Peer peer, int count = 20, int offset = 0, int startMessageID = -1, IEnumerable<string> fields = null)
        {
            var result = await _vkRequest.Dispath<VkResponse<DialogHistoryData>>(
                ApiMessages.GetDialogHistory(
                    AccessToken: _authData.AccessToken,
                    PeerID: ConvertIDIfChat(peer),
                    Offset: offset,
                    Count: count,
                    StartMessageID: startMessageID,
                    Fields: fields
                ));

            return result?.Response;
        }

        /// <summary>
        /// Получает приложения диалога
        /// </summary>
        /// <param name="mediaType">Тип</param>
        /// <param name="startFrom">Смещение</param>
        /// <param name="count">Кол-во</param>
        /// <param name="photoSizes">Возвращать фото в спиц формате</param>
        /// <param name="fields">Дополнительные поля</param>
        /// <returns></returns>
        public async Task<AttachmentData> GetDialogAttachment(Peer peer, string mediaType, string startFrom, int count = 10, bool photoSizes = false, IEnumerable<string> fields = null)
        {
            var result = await _vkRequest.Dispath<VkResponse<AttachmentData>>(
                ApiMessages.GetHistoryAttachments(
                    AccessToken: _authData.AccessToken,
                    PeerID: peer.ID,
                    MediaType: mediaType,
                    StartFrom: startFrom,
                    Count: count,
                    PhotoSizes: photoSizes,
                    Fields: fields    
                ));

            return result?.Response;
        }

        /// <summary>
        /// Получает информацию о чате
        /// </summary>
        /// <param name="chatID">ID чата</param>
        /// <param name="fields">Дополнительные поля</param>
        /// <returns></returns>
        public async Task<Chat> GetChat(int chatID, IEnumerable<string> fields = null)
        {
            var result = await _vkRequest.Dispath<VkResponse<Chat>>(
                ApiMessages.GetChat(
                    AccessToken: _authData.AccessToken,
                    ChatID: chatID,
                    Fields: fields
                ));

            return result?.Response;
        }

        /// <summary>
        /// Редактирует название чата
        /// </summary>
        /// <param name="chat">Чат</param>
        /// <param name="newTitle">Новое название</param>
        /// <returns></returns>
        public async Task<bool> EditChat(Chat chat, string newTitle)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.EditChat(
                    AccessToken: _authData.AccessToken,
                    ChatID: chat.ID,
                    Title: newTitle    
                ));

            return result != null;
        }

        /// <summary>
        /// Добавляет пользователя в чат
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="chat">Чат</param>
        /// <returns></returns>
        public async Task<bool> AddChatUser(User user, Chat chat)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.AddChatUser(
                    AccessToken: _authData.AccessToken,
                    ChatID: chat.ID,
                    UserID: user.ID
                ));

            return result == null ? false : result.Response == 1;
        }

        /// <summary>
        /// Удаляет пользователя из чата
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="chat">Чат</param>
        /// <returns></returns>
        public async Task<bool> RemoveChatUser(User user, Chat chat)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.RemoveChatUser(
                    AccessToken: _authData.AccessToken,
                    ChatID: chat.ID,
                    UserID: user.ID
                ));

            return result == null ? false : result.Response == 1;
        }

        /// <summary>
        /// Создает чат
        /// </summary>
        /// <param name="title">Название чата</param>
        /// <param name="users">Список пользователей</param>
        /// <returns></returns>
        public async Task<int> CreateChat(string title, IEnumerable<User> users)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.CreateChat(
                    AccessToken: _authData.AccessToken,
                    Title: title,
                    UserIDs: users.Select(u => u.ID)
                ));

            return result == null ? 0 : result.Response;
        }

        /// <summary>
        /// Удаляет диалог
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <returns></returns>
        public async Task<bool> DeleteDialog(Peer peer)
        {
            var result = await GetDialogHistory(peer, 1);
            if (result == null)
                return false;

            var deleteCallNumber = Math.Ceiling(result.Count / 10000d);
            //var deleteResponse = 0;

            for (int i = 0; i < deleteCallNumber; i++)
            {
                var delRes = await _vkRequest.Dispath<VkResponse<object>>(
                    ApiMessages.DeleteConversation(
                        AccessToken: _authData.AccessToken,
                        PeerID: ConvertIDIfChat(peer)
                    ));
                if (delRes == null)
                    return false;
            }
            return true;
        }

        #endregion

        #region Private methods

        private int ConvertIDIfChat(Peer peer)
        {
            if (peer.Type == "chat")
               return 2000000000 + peer.ID;
            return peer.ID;
        }

        private DialogRenderData[] GetDialogsRenderData(DialogsData dialogs, User[] users)
        {
            var result = new DialogRenderData[dialogs.Dialogs.Count()];
            for (int i = 0; i < result.Length; i++)
            {
                string peerName = "";

                if (dialogs.Dialogs[i].Type == "chat")
                    peerName = dialogs.Dialogs[i].Title;

                else if (dialogs.Dialogs[i].Type == "user")
                    peerName = users.Where(o => o.ID == dialogs.Dialogs[i].ID)
                                    .Select(o => o.FullName)
                                    .FirstOrDefault();

                result[i] = new DialogRenderData()
                {
                    Type = dialogs.Dialogs[i].Type,
                    ID = dialogs.Dialogs[i].ID,
                    UnreadMsgCount = dialogs.Dialogs[i].UnreadCount,
                    LastMessage = dialogs.Dialogs[i].LastMessage.Text,
                    DialogTime = dialogs.Dialogs[i].LastMessage.Date,
                    PeerName = peerName
                };
            }

            return result;
        }

        private IEnumerable<int> getUserIDs(DialogsData dd)
        {
            return dd.Dialogs.Where(d => d.Type.Equals("user"))
                             .Select(d => d.ID);
        }

        #endregion
    }
}
