namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Изменяет название беседы.
    /// </summary>
    public class EditChat : GetChat
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="ChatID">Id чата</param>
        /// <param name="Title">Новый заголовок</param>
        public EditChat(string AccessToken, string ChatID, string Title)
            :base(AccessToken, ChatID)
        {
            VkApiMethodName = "messages.editChat";
            this.Title = Title;
        }

        /// <summary>
        /// Новое название для беседы. 
        /// </summary>
        public string Title { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() + string.Format("&title={0}", Title);
        }
    }
}
