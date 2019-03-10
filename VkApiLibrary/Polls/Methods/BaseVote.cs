using VkApiSDK.Abstraction;

namespace VkApiSDK.Polls.Methods
{
    /// <summary>
    /// Базовый класс голосования
    /// </summary>
    public abstract class BaseVote : VkApiMethod
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>BaseVote</c>
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="OwnerID"></param>
        /// <param name="PollID"></param>
        /// <param name="IsBoard"></param>
        public BaseVote(string AccessToken, int OwnerID, int PollID, bool IsBoard = true)
            :base(AccessToken)
        {
            this.OwnerID = OwnerID;
            this.PollID = PollID;
            this.IsBoard = IsBoard;
        }

        /// <summary>
        /// Идентификатор пользователя или сообщества, которому принадлежит опрос
        /// </summary>
        public int OwnerID { get; set; }

        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        public int PollID { get; set; }

        /// <summary>
        /// Опрос находится в обсуждении
        /// </summary>
        public bool IsBoard { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&owner_id={0}&poll_id={1}&is_board={2}", OwnerID,
                                                                           PollID,
                                                                           IsBoard ? 1 : 0);
        }
    }
}
