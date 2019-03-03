using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Добавляет в мультидиалог нового пользователя.
    /// </summary>
    public class AddChatUser : VkApiMethod
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="ChatID">Идентификатор беседы. </param>
        /// <param name="UserID">Идентификатор пользователя, которого необходимо включить в беседу.</param>
        public AddChatUser(string AccessToken, string ChatID, string UserID)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.addChatUser";
            this.ChatID = ChatID;
            this.UserID = UserID;
        }

        /// <summary>
        /// Идентификатор беседы. 
        /// </summary>
        public string ChatID { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которого необходимо включить в беседу.
        /// </summary>
        public string UserID { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&chat_id={0}&user_id={1}", ChatID,
                                                             UserID);
        }
    }
}
