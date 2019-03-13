using VkApiSDK.Abstraction;

namespace VkApiSDK.Groups.Methods
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <c>SendLongPollRequest</c>
    /// </summary>
    class GetGroupLongPollServer : VkApiMethod
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>GetGroupLongPollServer</c>
        /// </summary>
        /// <param name="AccessToken"></param>
        public GetGroupLongPollServer(string AccessToken, int GroupID) 
            : base(AccessToken)
        {
            VkApiMethodName = "groups.getLongPollServer";
            this.GroupID = GroupID;
        }

        /// <summary>
        /// ID группы
        /// </summary>
        public int GroupID { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&=group_id{0}", GroupID);
        }
    }
}
