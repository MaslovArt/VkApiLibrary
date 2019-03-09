namespace VkApiSDK.Messages.Methods
{
    /// <summary>
    /// Исключает из мультидиалога пользователя, если текущий пользователь был создателем беседы 
    /// либо пригласил исключаемого пользователя.
    /// </summary>
    public class RemoveChatUser : AddChatUser
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="ChatID">Идентификатор беседы.</param>
        /// <param name="UserID">Идентификатор участника, которого необходимо исключить из беседы.</param>
        public RemoveChatUser(string AccessToken, int ChatID, int UserID)
            :base(AccessToken, ChatID, UserID)
        {
            VkApiMethodName = "messages.removeChatUser";
        }

        /// <summary>
        /// Идентификатор участника, которого необходимо исключить из беседы. 
        /// Для сообществ — идентификатор сообщества со знаком «минус». 
        /// </summary>
        public string MemberID { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams();
        }
    }
}
