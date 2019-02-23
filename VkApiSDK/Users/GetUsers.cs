using VkApiSDK.Requests;

namespace VkApiSDK.Users
{
    /// <summary>
    /// Возвращает расширенную информацию о пользователях.
    /// </summary>
    class GetUsers : VkApiMethod
    {
        public GetUsers(string AccessToken)
            :base(AccessToken)
        {
            VkApiMethodName = "users.get";
        }

        /// <summary>
        /// Идентификаторы пользователей или их короткие имена.
        /// </summary>
        public string[] UserIDs { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&user_ids={0}", ArrayToString(UserIDs));
        }
    }
}
