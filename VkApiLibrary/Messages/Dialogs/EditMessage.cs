namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Редактирует сообщение.
    /// </summary>
    public class EditMessage : SendMessage
    {
        public EditMessage(string AccessToken, string PeerID, string MessageID, string Message, string Attachments)
            :base(AccessToken, PeerID, Message, Attachments)
        {
            VkApiMethodName = "messages.edit";
            this.MessageID = MessageID;
        }

        /// <summary>
        /// Идентификатор сообщения.
        /// </summary>
        public string MessageID { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() + string.Format("&message_id={0}", MessageID);
        }
    }
}
