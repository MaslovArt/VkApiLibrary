
namespace VkApiSDK.Messages.Methods
{
    /// <summary>
    /// Редактирует сообщение.
    /// </summary>
    public class EditMessage : SendMessage
    {
        public EditMessage(string AccessToken, int PeerID, int MessageID, string Message, string Attachments)
            :base(AccessToken, PeerID, Message, Attachments)
        {
            VkApiMethodName = "messages.edit";
            this.MessageID = MessageID;
        }

        /// <summary>
        /// Идентификатор сообщения.
        /// </summary>
        public int MessageID { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() + string.Format("&message_id={0}", MessageID);
        }
    }
}
