using System.Collections.Generic;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Polls.Methods
{
    /// <summary>
    /// Отдает голос текущего пользователя за выбранный вариант ответа в указанном опросе.
    /// </summary>
    public class AddVote : BaseVote
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>AddVote</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="OwnerID">Идентификатор пользователя или сообщества, которому принадлежит опрос</param>
        /// <param name="PollID">Идентификатор опроса</param>
        /// <param name="AnswerIDs">Список идентификаторов ответа</param>
        /// <param name="IsBoard">Опрос находится в обсуждении</param>
        public AddVote(string AccessToken, int OwnerID, int PollID, IEnumerable<int> AnswerIDs, bool IsBoard = false)
            : base(AccessToken, OwnerID, PollID, IsBoard)
        {
            VkApiMethodName = "polls.addVote";
            this.AnswerIDs = AnswerIDs;
        }

        /// <summary>
        /// Список идентификаторов ответа (для опроса с мультивыбором)
        /// </summary>
        public IEnumerable<int> AnswerIDs { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() + 
                   string.Format("&answer_ids={0}", ArrayToString(AnswerIDs));
        }
    }
}
