namespace VkApiSDK.Groups.Methods
{
    /// <summary>
    /// Выключает статус «онлайн» в сообществе.
    /// </summary>
    class DisableOnline : EnableOnline
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>DisableOnline</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="GroupID">ID группы</param>
        public DisableOnline(string AccessToken, int GroupID)
            :base(AccessToken, GroupID)
        {
            VkApiMethodName = "groups.disableOnline";
        }
    }
}
