using System;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Friends.Methods
{
    /// <summary>
    /// Возвращает информацию о полученных или отправленных заявках на добавление в друзья для текущего пользователя. 
    /// </summary>
    public class GetRequests : VkApiMethod
    {
        int count;

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>AddFriend</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="Out">Bозвращать полученные заявки в друзья</param>
        /// <param name="NeedViewed">Bозвращать просмотренные заявки</param>
        /// <param name="Offset">Cмещение, необходимое для выборки определенного подмножества заявок на добавление в друзья.</param>
        /// <param name="Count">Максимальное количество заявок на добавление в друзья, которые необходимо получить</param>
        /// <param name="Extended">Требуется возвращать в ответе сообщения от пользователей, подавших заявку на добавление в друзья.</param>
        /// <param name="NeedMutual">Требуется возвращать в ответе список общих друзей, если они есть.</param>
        /// <param name="Sort">Cортировать по количеству общих друзей</param>
        /// <param name="Suggested">Bозвращать рекомендованных другими пользователями друзей</param>
        public GetRequests(string AccessToken, bool Out = false, bool NeedViewed = false, int Offset = 0, int Count = 100, bool Extended = false, bool NeedMutual = false, bool Sort = false, bool Suggested = false)
            :base(AccessToken)
        {
            VkApiMethodName = "friends.getRequests";
            this.Offset = Offset;
            this.Count = Count;
            this.Extended = Extended;
            this.NeedMutual = NeedMutual;
            this.Sort = Sort;
            this.NeedViewed = NeedViewed;
            this.Suggested = Suggested;
            this.Out = Out;
        }

        /// <summary>
        /// Cмещение, необходимое для выборки определенного подмножества заявок на добавление в друзья. 
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Максимальное количество заявок на добавление в друзья, которые необходимо получить (не более 1000)
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int Count
        {
            get { return count; }
            set
            {
                if (value > 1000)
                    throw new ArgumentException("максимальное количество заявок на добавление в друзья не более 1000");
                count = value;
            }
        }

        /// <summary>
        /// Требуется возвращать в ответе сообщения от пользователей, подавших заявку на добавление в друзья.
        /// </summary>
        public bool Extended { get; set; }

        /// <summary>
        /// Bозвращать полученные заявки в друзья
        /// </summary>
        public bool Out { get; set; }

        /// <summary>
        /// Требуется возвращать в ответе список общих друзей, если они есть.
        /// </summary>
        public bool NeedMutual { get; set; }

        /// <summary>
        /// Cортировать по количеству общих друзей
        /// </summary>
        public bool Sort { get; set; }

        /// <summary>
        /// Bозвращать просмотренные заявки
        /// </summary>
        public bool NeedViewed { get; set; }

        /// <summary>
        /// Bозвращать рекомендованных другими пользователями друзей
        /// </summary>
        public bool Suggested { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&offset={0}&count={1}&extended={2}&need_mutual={3}&out={4}&sort={5}&need_viewed={6}&suggested={7}", Offset,
                                                                                                                                      Count,
                                                                                                                                      Extended ? 1 : 0,
                                                                                                                                      NeedMutual ? 1 : 0,
                                                                                                                                      Out ? 1 : 0,
                                                                                                                                      Sort ? 1 : 0,
                                                                                                                                      NeedViewed ? 1 : 0,
                                                                                                                                      Suggested ? 1 : 0);
        }
    }
}
