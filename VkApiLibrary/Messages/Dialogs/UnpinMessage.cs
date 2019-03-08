using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Открепляет сообщение.
    /// </summary>
    public class UnpinMesaage : VkApiMethod
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="PeerID">Идентификатор назначения. </param>
        public UnpinMesaage(string AccessToken, int PeerID)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.unpin";
            this.PeerID = PeerID;
        }

        /// <summary>
        /// Идентификатор назначения. 
        /// </summary>
        public int PeerID { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&peer_id={0}", PeerID);
        }
    }
}
