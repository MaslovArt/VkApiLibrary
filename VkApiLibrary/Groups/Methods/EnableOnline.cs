namespace VkApiSDK.Groups.Methods
{
    /// <summary>
    /// Включает статус «онлайн» в сообществе.
    /// </summary>
    class EnableOnline : GetGroupLongPollServer
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>EnableOnline</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="GroupID">ID группы</param>
        public EnableOnline(string AccessToken, int GroupID)
            :base(AccessToken, GroupID)
        {
            VkApiMethodName = "groups.enableOnline";
        }
    }
}
