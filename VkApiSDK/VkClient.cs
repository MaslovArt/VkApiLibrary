using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Messages;
using VkApiSDK.Friends;
using VkApiSDK.Users;
using VkApiSDK.Errors;

namespace VkApiSDK
{
    public class VkClient
    {
        private AuthData _authData;
        private string token = "";
        private const string AUTH_DATA_FILE = "authData.dat";
        private int messageCount = 0;
        private int messageOffset = 0;

        private VkRequest _vkRequest;

        public event Action<Error> OnAccessDenied;
        //ToDo another error events

        public VkClient()
        {
            _vkRequest = new VkRequest();
        }

        public async Task AuthAsync()
        {
            var wasLoad = await DataSerialezer.LoadInfo(out _authData, AUTH_DATA_FILE);
            if (!wasLoad)
            {
                VkAutharization vkA = new VkAutharization(token);
                _authData = await vkA.AuthAsync();
                await DataSerialezer.SaveInfo(_authData, AUTH_DATA_FILE);
            }
        }

        public async Task<DialogsData> GetDialogs(int count = 20, int offset = -1)
        {
            if (offset > 0)
                messageOffset = offset;

            var result = await _vkRequest.Dispath<DialogsResponse>(
                new GetConversations(_authData.AccessToken)
                {
                    Count = count,
                    Offset = messageOffset
                });

            return result.DialogsData;
        }

        public async Task<FriendsData> GetFriends()
        {
            var result = await _vkRequest.Dispath<FriendsResponse>(
                new GetFriends(_authData.AccessToken)
                {
                    UserID = _authData.UserID
                });

            return result.FriendsData;
        }

        /// <summary>
        /// Получает информацию о пользователях
        /// </summary>
        /// <param name="userIDs">Набор id</param>
        /// <returns>Информацию о пользователя</returns>
        public async Task<User[]> GetUsers(params string[] userIDs)
        {
            var result = await _vkRequest.Dispath<UserResponse>(
                new GetUser(_authData.AccessToken)
                {
                    UserIDs = userIDs
                });

            return result.Users;
        }

        public async Task<DialogRenderData> GetNextDialogsRenderData(int count = 20)
        {
            var dialogs = await GetDialogs(count);
            messageOffset += 20;

            throw new NotImplementedException();
        }


        private string[] getUserIDs(DialogsData dd)
        {
            List<string> userIDs = new List<string>();
            foreach(Dialog dialog in dd.Dialogs)
            {
                
            }
        }
    }
}
