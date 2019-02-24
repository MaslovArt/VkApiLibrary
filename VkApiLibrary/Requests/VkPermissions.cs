namespace VkApiSDK.Requests
{
    /// <summary>
    /// Список названий прав доступа, которые необходимы приложению.
    /// </summary>
    public static class VkPermissions
    {
        /// <summary>
        /// Пользователь разрешил отправлять ему уведомления (для flash/iframe-приложений).
        /// </summary>
        public const string Notify = "notify";
        /// <summary>
        /// Доступ к друзьям.
        /// </summary>
        public const string Friends = "friends ";
        /// <summary>
        /// Доступ к фотографиям.
        /// </summary>
        public const string Photos = "photos";
        /// <summary>
        /// Доступ к аудиозаписям.
        /// </summary>
        public const string Audio = "audio";
        /// <summary>
        /// Доступ к видеозаписям.
        /// </summary>
        public const string Video = "video";
        /// <summary>
        /// Доступ к историям.
        /// </summary>
        public const string Stories = "stories";
        /// <summary>
        /// Доступ к wiki-страницам.
        /// </summary>
        public const string Pages = "pages";
        /// <summary>
        /// Доступ к статусу пользователя.
        /// </summary>
        public const string Status = "status";
        /// <summary>
        /// Доступ к заметкам пользователя.
        /// </summary>
        public const string Notes = "notes";
        /// <summary>
        /// Доступ к расширенным методам работы с сообщениями (только для Standalone-приложений).
        /// </summary>
        public const string Messages = "messages";
        /// <summary>
        /// Доступ к обычным и расширенным методам работы со стеной. 
        /// </summary>
        public const string Wall = "wall";
        /// <summary>
        /// Доступ к расширенным методам работы с рекламным API. 
        /// Доступно для авторизации по схеме Implicit Flow или Authorization Code Flow.
        /// </summary>
        public const string Ads = "ads";
        /// <summary>
        /// Доступ к API в любое время (при использовании этой опции параметр expires_in,
        /// возвращаемый вместе с access_token, содержит 0 — токен бессрочный).
        /// </summary>
        public const string Offline = "offline";
        /// <summary>
        /// Доступ к документам.
        /// </summary>
        public const string Docs = "docs";
        /// <summary>
        /// Доступ к группам пользователя.
        /// </summary>
        public const string Groups = "groups";
        /// <summary>
        /// Доступ к оповещениям об ответах пользователю.
        /// </summary>
        public const string Notifications = "notifications";
        /// <summary>
        /// Доступ к статистике групп и приложений пользователя, администратором которых он является.
        /// </summary>
        public const string Stats = "stats";
        /// <summary>
        /// Доступ к email пользователя.
        /// </summary>
        public const string Email = "email";

        /// <summary>
        /// Возвращает строку для scope.
        /// </summary>
        /// <param name="scopes">Массив разрещений</param>
        /// <returns>Строка</returns>
        public static string GetScopeString(params string[] scopes)
        {
            string result = "";
            if (scopes.Length > 0)
            {
                foreach (string scope in scopes)
                    result += "," + scope;
                result = result.Remove(0, 1);
            }

            return result;
        }
    }
}
