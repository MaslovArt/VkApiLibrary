using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Изменяет статус набора текста пользователем в диалоге.
    /// </summary>
    public class SetActivity : VkApiMethod
    {
        public SetActivity(string AccessToken, int PeerID, string Type = ActivityType.Typing)
            : base(AccessToken)
        {
            VkApiMethodName = "messages.setActivity";
            this.PeerID = PeerID;
            this.Type = Type;
        }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int PeerID { get; set; }

        /// <summary>
        /// Тип сообщения.
        /// </summary>
        public string Type { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&peer_id={0}&type={1}", PeerID, 
                                                          Type);
        }
    }

    /// <summary>
    /// Тип набираемого сообщения.
    /// </summary>
    public static class ActivityType
    {
        public const string Typing = "typing",
                            Audiomessage = "audiomessage";
    }
}
