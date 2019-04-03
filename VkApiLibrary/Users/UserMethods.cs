using System.Collections.Generic;
using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using VkApiSDK.Auth;
using VkApiSDK.Models;
using VkApiSDK.Models.Response;
using VkApiSDK.Users.Methods;

namespace VkApiSDK.Users
{
    /// <summary>
    /// Методы для работы с пользователями
    /// </summary>
    public class UserMethods : VkApiMethodGroup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>MessageMethods</c>
        /// </summary>
        /// <param name="AuthData">Токен доступа</param>
        /// <param name="VkRequest">Класс для отправки запросов</param>
        public UserMethods(AuthData AuthData, IVkRequest VkRequest = null)
            : base(AuthData, VkRequest)
        { }

        /// <summary>
        /// Получает информацию о пользователях
        /// </summary>
        /// <param name="userIDs">Набор id</param>
        /// <returns>Информацию о пользователя</returns>
        public async Task<VkResponse<User[]>> GetUsersAsync(IEnumerable<int> userIDs, IEnumerable<string> fields = null)
        {
            return await _vkRequest.Dispath<VkResponse<User[]>>(
                new GetUsers(
                    AccessToken: AuthData.AccessToken,
                    UserIDs: userIDs,
                    Fields: fields
                ));
        }

        /// <summary>
        /// Получает информацию о пользователе
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        /// <param name="fields">Дополнительные поля</param>
        /// <returns>Информацию о пользователя</returns>
        public async Task<VkResponse<User>> GetUserAsync(int userID, IEnumerable<string> fields = null)
        {
            var response =  await GetUsersAsync(new int[] { userID }, fields);
            var result = new VkResponse<User>();
            if (response.IsSucceed)
                result.Response = response.Response[0];
            else
                result.Error = response.Error;

            return result;
        }

        /// <summary>
        /// Получает информацию о текущем пользователе
        /// </summary>
        /// <param name="fields">Дополнительные поля</param>
        /// <returns>The current user.</returns>
        public async Task<VkResponse<User>> GetCurrentUser(IEnumerable<string> fields = null)
        {
            return await GetUserAsync(AuthData.UserID, fields);
        }
    }
}
