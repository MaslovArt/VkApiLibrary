using System.Collections.Generic;
using System.Threading.Tasks;
using VkApiSDK.Abstraction;
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
        public async Task<User[]> GetUsersAsync(IEnumerable<int> userIDs, IEnumerable<string> fields = null)
        {
            var result = await _vkRequest.Dispath<VkResponse<User[]>>(
                new GetUsers(
                    AccessToken: AuthData.AccessToken,
                    UserIDs: userIDs,
                    Fields: fields
                ));

            return result?.Response;
        }
    }
}
