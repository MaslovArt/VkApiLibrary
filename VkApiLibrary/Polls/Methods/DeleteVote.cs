namespace VkApiSDK.Polls.Methods
{
    /// <summary>
    /// Снимает голос текущего пользователя с выбранного варианта ответа в указанном опросе.
    /// </summary>
    public class DeleteVote : BaseVote
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>DeleteVote</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="OwnerID">Идентификатор пользователя или сообщества, которому принадлежит опрос</param>
        /// <param name="PollID">Идентификатор опроса</param>
        /// <param name="AnswerID">Идентификатор ответа</param>
        /// <param name="IsBoard">Опрос находится в обсуждении</param>
        public DeleteVote(string AccessToken, int OwnerID, int PollID, int AnswerID, bool IsBoard = true)
            : base(AccessToken, OwnerID, PollID, IsBoard)
        {
            VkApiMethodName = "polls.deleteVote";
            this.AnswerID = AnswerID;
        }

        /// <summary>
        /// Идентификаторов ответа
        /// </summary>
        public int AnswerID { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() + 
                   string.Format("&answer_ids={0}", AnswerID);
        }
    }
}
