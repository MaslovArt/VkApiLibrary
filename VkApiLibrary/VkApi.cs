using VkApiSDK.Abstraction;
using VkApiSDK.Requests;
using VkApiSDK.Friends;
using VkApiSDK.Users;
using VkApiSDK.Messages;
using VkApiSDK.LongPoll;
using VkApiSDK.Account;
using VkApiSDK.Polls;
using VkApiSDK.Auth;
using System.Threading.Tasks;
using VkApiSDK.Models.Messages;
using VkApiSDK.Models;
using System.Collections.Generic;
using System.Linq;
using VkApiSDK.Models.Response;

namespace VkApiSDK
{
    /// <summary>
    /// Позволяет работать с api Вк
    /// </summary>
    public class VkApi
    {
        private IVkRequest vkRequest;
        private static VkApi _vkApi;

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>VkApi</c>
        /// </summary>
        /// <param name="authData">Auth data.</param>
        private VkApi(AuthData authData)
        {
            AuthData = authData;
            initApiMethodGroups();
            _vkApi = this;
        }

        /// <summary>
        /// Возврашает ссылку на существующий объект VkApi
        /// </summary>
        /// <returns></returns>
        public static VkApi GetInstance(AuthData authData)
        {
            if (_vkApi == null)
                return new VkApi(authData);

            return _vkApi;
        }

        #region Properties

        /// <summary>
        /// ID приложения
        /// </summary>
        public string AppID { get; private set; }

        /// <summary>
        /// Список разрешений
        /// </summary>
        public string Scope { get; private set; }

        /// <summary>
        /// Токен доступа
        /// </summary>
        public AuthData AuthData { get; private set; }

        #endregion

        #region VkApi

        /// <summary>
        /// Методы для работы с друзьями
        /// </summary>
        public FriendMethods Friends { get; private set; }

        /// <summary>
        /// Методы для работы с пользователями
        /// </summary>
        public UserMethods Users { get; private set; }

        /// <summary>
        /// Методы для работы с сообщениями
        /// </summary>
        public MessageMethods Messages { get; private set; }

        /// <summary>
        /// Методы для работы с чатами
        /// </summary>
        public ChatMethods Chats { get; private set; }

        /// <summary>
        /// Методы для работы с акаунтом
        /// </summary>
        public AccountMethods Account { get; private set; }

        /// <summary>
        /// Методы для работы с голосованием
        /// </summary>
        public PollMethdos Polls { get; private set; }

        /// <summary>
        /// Методы для работы с новыми событиями
        /// </summary>
        public LongPollManager LongPollService { get; private set; }

        #endregion

        #region VkApi Extentions

        /// <summary>
        /// Получает необходимые для отображения диалога данные.
        /// </summary>
        /// <param name="count">Кол-во диалогов</param>
        /// <returns>Диалоги</returns>
        public async Task<VkResponse<DialogRenderData[]>> GetDialogsRenderDataAsync(int count = 20, int offset = 0)
        {
            var result = new VkResponse<DialogRenderData[]>();

            var dialogs = await Messages.GetDialogsAsync(count, offset);
            if (!dialogs.IsSucceed)
            {
                result.Error = dialogs.Error;
                return result;
            }

            var userIDs = getUserIDs(dialogs.Response);
            var users = await Users.GetUsersAsync(userIDs);
            if (!users.IsSucceed)
            {
                result.Error = users.Error;
                return result;
            }

            result.Response = GetDialogsRenderData(dialogs.Response, users.Response);

            return result;
        }

        #endregion

        #region Private Method

        private DialogRenderData[] GetDialogsRenderData(DialogsData dialogs, User[] users)
        {
            var result = new DialogRenderData[dialogs.Items.Count()];
            for (int i = 0; i < result.Length; i++)
            {
                string peerName = "";

                if (dialogs.Items[i].Type == "chat")
                    peerName = dialogs.Items[i].Title;

                else if (dialogs.Items[i].Type == "user")
                    peerName = users.Where(o => o.ID == dialogs.Items[i].ID)
                                    .Select(o => o.FullName)
                                    .FirstOrDefault();

                result[i] = new DialogRenderData()
                {
                    Type = dialogs.Items[i].Type,
                    ID = dialogs.Items[i].ID,
                    UnreadMsgCount = dialogs.Items[i].UnreadCount,
                    LastMessage = dialogs.Items[i].LastMessage.Text,
                    DialogTime = dialogs.Items[i].LastMessage.Date,
                    PeerName = peerName,
                    Out = dialogs.Items[i].LastMessage.Out == 1
                };
            }

            return result;
        }

        private IEnumerable<int> getUserIDs(DialogsData dd)
        {
            return dd.Items.Where(d => d.Type.Equals("user"))
                           .Select(d => d.ID);
        }

        private void initApiMethodGroups()
        {
            vkRequest = new VkRequest();
            Friends = new FriendMethods(AuthData, vkRequest);
            Users = new UserMethods(AuthData, vkRequest);
            Messages = new MessageMethods(AuthData, vkRequest);
            Chats = new ChatMethods(AuthData, vkRequest);
            Account = new AccountMethods(AuthData, vkRequest);
            Polls = new PollMethdos(AuthData, vkRequest);
            LongPollService = new LongPollManager(AuthData, vkRequest);
        }

        #endregion
    }
}
