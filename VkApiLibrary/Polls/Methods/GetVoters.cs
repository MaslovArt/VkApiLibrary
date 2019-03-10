using System;
using System.Collections.Generic;

namespace VkApiSDK.Polls.Methods
{
    /// <summary>
    /// Получает список идентификаторов пользователей, которые выбрали определенные варианты ответа в опросе.
    /// </summary>
    public class GetVoters : BaseVote
    {
        private int count;
        private bool friendsOnly;

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>AddVote</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="OwnerID">Идентификатор пользователя или сообщества, которому принадлежит опрос</param>
        /// <param name="PollID">Идентификатор опроса</param>
        /// <param name="AnswerIDs">Идентификаторы вариантов ответа</param>
        /// <param name="FriendsOnly">Необходимо возвращать только пользователей, которые являются друзьями текущего пользователя</param>
        /// <param name="Offset">Смещение относительно начала списка, для выборки определенного подмножества</param>
        /// <param name="Count">Количество возвращаемых идентификаторов пользователей</param>
        /// <param name="IsBoard">Опрос находится в обсуждении</param>
        /// <param name="NameCase">Падеж для склонения имени и фамилии пользователя</param>
        public GetVoters(string AccessToken, int OwnerID, int PollID, IEnumerable<int> AnswerIDs, bool FriendsOnly = false,
            int Offset = 0, int Count = 40, bool IsBoard = true, string NameCase = "nom")
            :base(AccessToken, OwnerID, PollID, IsBoard)
        {
            VkApiMethodName = "polls.getVoters";
            this.AnswerIDs = AnswerIDs;
            this.FriendsOnly = FriendsOnly;
            this.Offset = Offset;
            this.Count = Count;
            this.NameCase = NameCase;
        }

        /// <summary>
        /// Идентификаторы вариантов ответа
        /// </summary>
        public IEnumerable<int> AnswerIDs { get; set; }

        /// <summary>
        /// Необходимо возвращать только пользователей, которые являются друзьями текущего пользователя
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public bool FriendsOnly
        {
            get { return friendsOnly; }
            set
            {
                if (Count > 1000 || (Count > 100 && value))
                    throw new ArgumentException("Максимальное значение параметра Count 1000, если не задан параметр friends_only, в противном случае 100.");
                friendsOnly = value;
            }
        }

        /// <summary>
        /// Смещение относительно начала списка, для выборки определенного подмножества
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Количество возвращаемых идентификаторов пользователей
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int Count
        {
            get { return count; }
            set
            {
                if (value > 1000 || (value > 100 && FriendsOnly))
                    throw new ArgumentException("Максимальное значение параметра Count 1000, если не задан параметр friends_only, в противном случае 100.");
                count = value;
            }
        }

        /// <summary>
        /// Падеж для склонения имени и фамилии пользователя
        /// </summary>
        public string NameCase { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() +
                   string.Format("&answer_ids={0}&friends_only={1}&offset={2}&count={3}&name_case={4}", ArrayToString(AnswerIDs),
                                                                                                        FriendsOnly ? 1 : 0,
                                                                                                        Offset,
                                                                                                        Count,
                                                                                                        NameCase);
        }
    }
}
