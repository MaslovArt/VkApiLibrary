using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkApiSDK.Friends;
using VkApiSDK.Users;
using VkApiSDK.Errors;
using VkApiSDK.Messages.Dialogs;
using VkApiSDK.Messages;
using VkApiSDK.Requests;
using VkApiSDK.Interfaces;

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

        public VkClient(string AppID, string Scope, IDataProvider DataProvider = null)
        {
            this.AppID = AppID;
            this.Scope = Scope;
            this.DataProvider = DataProvider;

            _vkRequest = new VkRequest();
        }

        #region Properties

        public string AppID { get; private set; }

        public string Scope { get; private set; }

        public IDataProvider DataProvider { get; set; }

        #endregion

        #region Vk api methods

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <returns></returns>
        public bool Auth(Func<string, string, string, AuthData> AuthMethod)
        {
            VkAutharization vka = new VkAutharization(AppID, Scope, DataProvider, AuthMethod);
            _authData = vka.Auth();

            return _authData != null;
        }

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

            return result.IsResultNull() ? null : result.Response;
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
                        ApiField.Photo50,
                        ApiField.IsOnline
                    },
                    Count: count,
                    Offset: offset
               ));

            return result.IsResultNull() ? null : result.Response;
        }

        /// <summary>
        /// Получает список id онлайн друзей
        /// </summary>
        /// <returns>Массив айди пользователей</returns>
        public async Task<string[]> GetOnlineFriendIDsAsync()
        {
            var result = await _vkRequest.Dispath<VkResponse<string[]>>(
                ApiFriends.GetOnlineFriends(
                    AccessToken: _authData.AccessToken,
                    UserID: _authData.UserID
                ));

            return result.IsResultNull() ? null : result.Response;
        }

        /// <summary>
        /// Получает информацию о пользователях
        /// </summary>
        /// <param name="userIDs">Набор id</param>
        /// <returns>Информацию о пользователя</returns>
        public async Task<User[]> GetUsersAsync(IEnumerable<string> userIDs, IEnumerable<string> fields = null)
        {
            var result = await _vkRequest.Dispath<VkResponse<User[]>>(
                ApiUsers.Get(
                    AccessToken: _authData.AccessToken,
                    UserIDs: userIDs,
                    Fields: fields
                ));

            return result.IsResultNull() ? null : result.Response;
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
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<string> SendMessage(Peer peer, string message)
        {
            var result = await _vkRequest.Dispath<VkResponse<string>>(
                ApiMessages.SendMessage(
                    AccessToken: _authData.AccessToken,
                    PeedID: peer.ID,
                    Message: message,
                    Attachments: ""
                ));

            return result.Response ?? string.Empty;
        }

        public async Task<Dictionary<string, int>> DeleteMessage(IEnumerable<string> MessageIDs, bool DeleteForAll = true)
        {
            var result = await _vkRequest.Dispath<VkResponse<Dictionary<string, int>>>(
                ApiMessages.DeleteMessage(
                    AccessToken: _authData.AccessToken,
                    MessageIDs: MessageIDs,
                    DeleteForAll: DeleteForAll
                ));

            return result.Response ?? null;
        } 

        public async Task<bool> SetActivity(User user, string activityType)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                ApiMessages.SetActivity(
                    AccessToken: _authData.AccessToken,
                    UserID: user.ID,
                    ActivityType: activityType
                ));

            return result.IsResultNull();
        }

        public async Task<DialogHistoryData> GetDialogHistory(User user, int offset = 0, int count = 20, int startMessageID = -1, IEnumerable<string> fields = null)
        {
            var result = await _vkRequest.Dispath<VkResponse<DialogHistoryData>>(
                ApiMessages.GetDialogHistory(
                    AccessToken: _authData.AccessToken,
                    UserID: user.ID,
                    Offset: offset,
                    Count: count,
                    StartMessageID: startMessageID,
                    Fields: fields
                ));

            return result.IsResultNull() ? null : result.Response;
        }

        #endregion

        #region Private methods

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

        private IEnumerable<string> getUserIDs(DialogsData dd)
        {
            return dd.Dialogs.Where(d => d.Type.Equals("user"))
                             .Select(d => d.ID.ToString());
        }

        #endregion
    }
}
