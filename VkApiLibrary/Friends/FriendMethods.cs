using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using VkApiSDK.Friends.Methods;
using VkApiSDK.Models.Friends;
using VkApiSDK.Requests;

namespace VkApiSDK.Friends
{
    /// <summary>
    /// Методы для работы с друзьями. 
    /// </summary>
    public class FriendMethods : VkApiMethodGroup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>FriendMethods</c>
        /// </summary>
        /// <param name="AuthData">Токен доступа</param>
        /// <param name="VkRequest">Класс для отправки запросов</param>
        public FriendMethods(AuthData AuthData, IVkRequest VkRequest = null)
            :base(AuthData, VkRequest)
        { }

        /// <summary>
        /// Получает список друзей
        /// </summary>
        /// <param name="count">Кол-во друзей в запросе</param>
        /// <param name="offset">Смещение для получения данных</param>
        /// <returns>Друзей пользователя</returns>
        public async Task<FriendsData> GetFriendsAsync(int count = 5000, int offset = 0)
        {
            var result = await _vkRequest.Dispath<VkResponse<FriendsData>>(
                new GetFriends(
                    AccessToken: AuthData.AccessToken,
                    UserID: AuthData.UserID,
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
                new GetOnlineFriends(
                    AccessToken: AuthData.AccessToken,
                    UserID: AuthData.UserID
                ));

            return result?.Response;
        }
    }
}
