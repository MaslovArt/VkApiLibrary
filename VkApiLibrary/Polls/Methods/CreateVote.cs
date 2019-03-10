using System.Collections.Generic;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Polls.Methods
{
    /// <summary>
    /// Позволяет создавать опросы, которые впоследствии можно прикреплять к записям на странице пользователя или сообщества.
    /// </summary>
    public class CreateVote : VkApiMethod
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса<c>CreateVote</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="OwnerID">Владелец</param>
        /// <param name="QuestionText">Tекст вопроса</param>
        /// <param name="Answers">Список вариантов ответов</param>
        /// <param name="IsAnanimus">Aнонимный опрос</param>
        /// <param name="IsMultipleVote">Cоздания опроса с мультивыбором</param>
        /// <param name="EndDate">Дата завершения опроса в Unixtime</param>
        /// <param name="BackgroundID">Идентификатор стандартного фона для сниппета</param>
        public CreateVote(string AccessToken, int OwnerID, string QuestionText, IEnumerable<string> Answers, bool IsAnanimus = false, bool IsMultipleVote = false, long EndDate = 0, int BackgroundID = 1)
            :base(AccessToken)
        {
            VkApiMethodName = "polls.create";
            this.QuestionText = QuestionText;
            this.IsAnanimus = IsAnanimus;
            this.IsMultipleVote = IsMultipleVote;
            this.EndDate = EndDate;
            this.OwnerID = OwnerID;
            this.Answers = Answers;
            this.BackgroundID = BackgroundID;
        }

        /// <summary>
        /// Tекст вопроса
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Aнонимный опрос
        /// </summary>
        public bool IsAnanimus { get; set; }

        /// <summary>
        /// Cоздания опроса с мультивыбором
        /// </summary>
        public bool IsMultipleVote { get; set; }

        /// <summary>
        /// Дата завершения опроса в Unixtime. 
        /// </summary>
        public long EndDate { get; set; }

        /// <summary>
        /// Владелец
        /// </summary>
        public int OwnerID { get; set; }

        /// <summary>
        /// Список вариантов ответов
        /// </summary>
        public IEnumerable<string> Answers { get; set; }

        /// <summary>
        /// Идентификатор стандартного фона для сниппета
        /// </summary>
        public int BackgroundID { get; set; }


        protected override string GetMethodApiParams()
        {
            return string.Format("&question={0}&is_anonymous={1}&is_multiple={2}&end_date={3}" +
                                 "&owner_id={4}&add_answers={5}&background_id={6}", QuestionText,
                                                                                    IsAnanimus ? 1 : 0,
                                                                                    IsMultipleVote ? 1 : 0,
                                                                                    EndDate,
                                                                                    OwnerID,
                                                                                    "[\"" + string.Join("\",\"", Answers) + "\"]",
                                                                                    BackgroundID);
        }
    }
}
