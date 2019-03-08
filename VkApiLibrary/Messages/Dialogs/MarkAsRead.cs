using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Помечает сообщения как прочитанные.
    /// </summary>
    public class MarkAsRead : VkApiMethod
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="PeerID">Идентификатор назначения</param>
        /// <param name="StartMessageID">При передаче этого параметра будут помечены как прочитанные все сообщения, начиная с данного.</param>
        public MarkAsRead(string AccessToken, int PeerID, int StartMessageID)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.markAsRead";
            this.PeerID = PeerID;
            this.StartMessageID = StartMessageID;
        }

        /// <summary>
        /// Идентификатор назначения.
        /// </summary>
        public int PeerID { get; set; }

        /// <summary>
        /// При передаче этого параметра будут помечены как прочитанные все сообщения, начиная с данного. 
        /// </summary>
        public int StartMessageID { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&peer_id={0}&start_message_id={1}", PeerID,
                                                                      StartMessageID);
        }
    }
}
