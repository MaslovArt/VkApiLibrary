namespace VkApiSDK.Groups.Methods
{
    /// <summary>
    /// Получает настройки Bots Longpoll API для сообщества.
    /// </summary>
    class GetLongPollSettings : GetGroupLongPollServer
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>GetLongPollSettings</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="GroupID">ID группы</param>
        public GetLongPollSettings(string AccessToken, int GroupID)
            :base(AccessToken, GroupID)
        {
            VkApiMethodName = "groups.getLongPollSettings"; 
        }
    }
}
