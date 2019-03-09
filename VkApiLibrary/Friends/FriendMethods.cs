﻿using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using VkApiSDK.Friends.Methods;
using VkApiSDK.Models;
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
        public async Task<User[]> GetFriendsAsync(int count = 5000, int offset = 0)
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

            return result?.Response.Friends;
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

        /// <summary>
        /// Одобряет или создает заявку на добавление в друзья
        /// </summary>
        /// <returns>
        /// 0 - ошибка;
        /// 1 — заявка на добавление данного пользователя в друзья отправлена; 
        /// 2 — заявка на добавление в друзья от данного пользователя одобрена;
        /// 4 — повторная отправка заявки.
        /// </returns>
        public async Task<int> AddFriend(User User, bool Follow, string Text = "")
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                new AddFriend(
                    AccessToken: AuthData.AccessToken,
                    UserID: User.ID,
                    Text: Text,
                    Follow: Follow
                ));

            return result == null ? 0 : result.Response;
        }

        /// <summary>
        /// Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
        /// </summary>
        /// <param name="User">Пользователь для удаления</param>
        /// <returns></returns>
        public async Task<DeleteFriendData> DeleteFriend(User User)
        {
            var result = await _vkRequest.Dispath<VkResponse<DeleteFriendData>>(
                new DeleteFriend(
                    AccessToken: AuthData.AccessToken,
                    UserID: User.ID
                ));

            return result?.Response;
        }

        /// <summary>
        /// Возвращает информацию о полученных или отправленных заявках на добавление в друзья для текущего пользователя. 
        /// </summary>
        /// <param name="Out">Bозвращать полученные заявки в друзья</param>
        /// <param name="NeedViewed">Bозвращать просмотренные заявки</param>
        /// <param name="Offset">Cмещение, необходимое для выборки определенного подмножества заявок на добавление в друзья.</param>
        /// <param name="Count">Максимальное количество заявок на добавление в друзья, которые необходимо получить</param>
        /// <returns></returns>
        public async Task<FriendsData> GetRequests(bool Out = false, bool NeedViewed = false, int Offset = 0, int Count = 100)
        {
            var result = await _vkRequest.Dispath<VkResponse<FriendsData>>(
                new GetRequests(
                    AccessToken: AuthData.AccessToken,
                    Out: Out,
                    NeedViewed: NeedViewed,
                    Count: Count,
                    Offset: Offset
                ));

            return result?.Response;
        }
    }
}
