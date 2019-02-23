using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkApiSDK.Friends;
using VkApiSDK.Users;
using VkApiSDK.Errors;
using VkApiSDK.Messages.Dialogs;
using VkApiSDK.Requests;

namespace VkApiSDK
{
    public class VkClient
    {
        #region Variables

        private readonly string AppID = "6871136",
                                Scope = VkPermissions.GetScopeString(VkPermissions.Friends, VkPermissions.Offline); //messages

        private AuthData _authData;
        private int messageCount = 0;
        private int messageOffset = 0;

        private VkRequest _vkRequest;

        #endregion

        #region Events

        public event Action<Error> OnRequestError;
        //ToDo another error events

        #endregion

        public VkClient()
        {
            _vkRequest = new VkRequest();
        }

        #region Properties

        #endregion

        #region Vk api methods

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <returns></returns>
        public async Task AuthAsync(Func<string, string, string, AuthData> authMethod)
        {
            VkAutharization vka = new VkAutharization(AppID, Scope, authMethod);
            _authData = await vka.AuthAsync();
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
                new GetConversations(_authData.AccessToken)
                {
                    Count = count,
                    Offset = offset
                });

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
                new GetFriends(_authData.AccessToken)
                {
                    UserID = _authData.UserID,
                    Count = count,
                    Offset = offset,
                    Fields = new string[]
                    {
                        ApiField.Photo50,
                        ApiField.LastOnline,
                        ApiField.IsOnline
                    }
                });

            return result.IsResultNull() ? null : result.Response;
        }

        /// <summary>
        /// Получает список id онлайн друзей
        /// </summary>
        /// <returns>Массив айди пользователей</returns>
        public async Task<string[]> GetOnlineFriendIDsAsync()
        {
            var result = await _vkRequest.Dispath<VkResponse<string[]>>(
                new GetOnlineFriends(_authData.AccessToken)
                {
                    UserID = _authData.UserID
                });

            return result.IsResultNull() ? null : result.Response;
        }

        /// <summary>
        /// Получает информацию о пользователях
        /// </summary>
        /// <param name="userIDs">Набор id</param>
        /// <returns>Информацию о пользователя</returns>
        public async Task<User[]> GetUsersAsync(string[] Fields = null, params string[] userIDs)
        {
            var result = await _vkRequest.Dispath<VkResponse<User[]>>(
                new GetUsers(_authData.AccessToken)
                {
                    UserIDs = userIDs,
                    Fields = Fields ?? new string[] { }
                });

            return result.IsResultNull() ? null : result.Response;
        }


        #endregion

        #region SDK api

        /// <summary>
        /// Получает необходимые для отображения диалога данные.
        /// </summary>
        /// <param name="count">Кол-во диалогов</param>
        /// <returns>Диалоги</returns>
        public async Task<DialogRenderData[]> GetNextDialogsDataAsync(int count = 20)
        {
            var dialogs = await GetDialogsAsync(count, messageOffset);
            var userIDs = getUserIDs(dialogs);
            var users = await GetUsersAsync(userIDs);

            DialogRenderData[] result = GetDialogsRenderData(dialogs, users);

            messageOffset += count;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<User[]> GetOnlineFriendsAsync()
        {
            var onlineFriendIDs = await GetOnlineFriendIDsAsync();
            var onlineFriendsData = await GetUsersAsync(onlineFriendIDs);

            return onlineFriendsData;
        }

        /// <summary>
        /// Обнулет смещение для получения диалогов.
        /// </summary>
        public void ClearMessageOffset()
        {
            messageOffset = 0;
        }

        #endregion

        #region Private methods

        private DialogRenderData[] GetDialogsRenderData(DialogsData dialogs, User[] users)
        {
            var result = new DialogRenderData[dialogs.Dialogs.Count()];
            for (int i = 0; i < result.Length; i++)
            {
                string peerName = "";

                if (dialogs.Dialogs[i].Conversation.Peer.Type == "chat")
                    peerName = dialogs.Dialogs[i].Conversation.ChatSettings.Title;

                else if (dialogs.Dialogs[i].Conversation.Peer.Type == "user")
                    peerName = users.Where(o => o.ID == dialogs.Dialogs[i].Conversation.Peer.ID)
                                    .Select(o => o.FullName)
                                    .FirstOrDefault();

                result[i] = new DialogRenderData()
                {
                    Type = dialogs.Dialogs[i].Conversation.Peer.Type,
                    ID = dialogs.Dialogs[i].Conversation.Peer.ID,
                    UnreadMsgCount = dialogs.Dialogs[i].Conversation.UnreadCount,
                    LastMessage = dialogs.Dialogs[i].Message.Text,
                    DialogTime = dialogs.Dialogs[i].Message.Date,
                    PeerName = peerName
                };
            }

            return result;
        }

        private string[] getUserIDs(DialogsData dd)
        {
            List<string> userIDs = new List<string>();
            foreach(Dialog dialog in dd.Dialogs)
            {
                if (dialog.Conversation.Peer.Type == "user")
                    userIDs.Add(dialog.Conversation.Peer.ID.ToString());
            }
            return userIDs.ToArray();
        }

        #endregion
    }
}
