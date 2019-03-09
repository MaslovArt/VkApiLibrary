namespace VkApiSDK.Messages.Methods
{
    /// <summary>
    /// Закрепляет сообщение.
    /// </summary>
    public class PinMessage : UnpinMesaage
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="PeerID">Идентификатор назначения. </param>
        /// <param name="MessageID">Идентификатор сообщения, которое нужно закрепить.</param>
        public PinMessage(string AccessToken, int PeerID, int MessageID)
            :base(AccessToken, PeerID)
        {
            VkApiMethodName = "messages.pin";
            this.MessageID = MessageID;

        }

        /// <summary>
        /// Идентификатор сообщения, которое нужно закрепить.
        /// </summary>
        public int MessageID { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() + string.Format("&message_id={0}", MessageID);
        }
    }
}
