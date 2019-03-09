namespace VkApiSDK.Account.Methods
{
    /// <summary>
    /// Удаляет пользователя или группу из черного списка.
    /// </summary>
    public class UnBan : Ban
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>UnBan</c>
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="PeerID"></param>
        public UnBan(string AccessToken, int PeerID)
            :base(AccessToken, PeerID)
        {
            VkApiMethodName = "account.unban";
        }
    }
}
