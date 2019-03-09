using VkApiSDK.Abstraction;

namespace VkApiSDK.Account.Methods
{
    /// <summary>
    /// Добавляет пользователя или группу в черный список.
    /// </summary>
    public class Ban : VkApiMethod
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>Ban</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="PeerID">Идентификатор пользователя или сообщества</param>
        public Ban(string AccessToken, int PeerID)
            : base(AccessToken)
        {
            VkApiMethodName = "account.ban";
            this.PeerID = PeerID;
        }

        /// <summary>
        /// Идентификатор пользователя или сообщества. 
        /// </summary>
        public int PeerID { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&owner_id={0}", PeerID);
        }
    }
}
