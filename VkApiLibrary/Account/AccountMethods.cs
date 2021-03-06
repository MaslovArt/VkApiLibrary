﻿using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using VkApiSDK.Models;
using VkApiSDK.Models.Response;
using VkApiSDK.Account.Methods;
using VkApiSDK.Models.Account;
using System.Collections.Generic;
using VkApiSDK.Auth;

namespace VkApiSDK.Account
{
    /// <summary>
    /// Методы для работы с акаунтом
    /// </summary>
    public class AccountMethods : VkApiMethodGroup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>AccountMethods</c>
        /// </summary>
        /// <param name="AuthData">Токен доступа</param>
        /// <param name="VkRequest">Класс для отправки запросов</param>
        public AccountMethods(AuthData AuthData, IVkRequest VkRequest)
            : base(AuthData, VkRequest)
        { }

        /// <summary>
        /// Добавляет пользователя или группу в черный список.
        /// </summary>
        /// <param name="User">Пользователь</param>
        /// <returns>Успех операции</returns>
        public async Task<VkResponse<int>> Ban(User User)
        {
            return await _vkRequest.Dispath<VkResponse<int>>(
                new Ban(
                    AccessToken: AuthData.AccessToken,
                    PeerID: User.ID
                ));
        }

        /// <summary>
        /// Удаляет пользователя или группу из черного списка.
        /// </summary>
        /// <param name="User">Пользователь</param>
        /// <returns></returns>
        public async Task<VkResponse<int>> UnBan(User User)
        {
            return await _vkRequest.Dispath<VkResponse<int>>(
                new UnBan(
                    AccessToken: AuthData.AccessToken,
                    PeerID: User.ID
                ));
        }

        /// <summary>
        /// Возвращает список пользователей, находящихся в черном списке.
        /// </summary>
        /// <param name="Offset">Cмещение, необходимое для выборки определенного подмножества черного списка.</param>
        /// <param name="Count">Kоличество объектов, информацию о которых необходимо вернуть.</param>
        /// <returns></returns>
        public async Task<VkResponse<BannedData>> GetBanned(int Offset = 0, int Count = 20)
        {
            return await _vkRequest.Dispath<VkResponse<BannedData>>(
                new GetBanned(
                    AccessToken: AuthData.AccessToken,
                    Offset: Offset,
                    Count: Count
                ));
        }

        /// <summary>
        /// Возвращает ненулевые значения счетчиков пользователя.
        /// </summary>
        /// <param name="Filters">Фильтр ответа</param>
        /// <returns></returns>
        public async Task<VkResponse<CountersData>> GetCounters(IEnumerable<string> Filters)
        {
            return await _vkRequest.Dispath<VkResponse<CountersData>>(
                new GetCounters(
                    AccessToken: AuthData.AccessToken,
                    Filters: Filters
                ));
        }

        /// <summary>
        /// Возвращает информацию о текущем профиле.
        /// </summary>
        /// <returns>The profile info.</returns>
        public async Task<VkResponse<User>> GetProfileInfo()
        {
            return await _vkRequest.Dispath<VkResponse<User>>(
                new GetProfileInfo(
                    AccessToken: AuthData.AccessToken
                ));
        }
    }
}
