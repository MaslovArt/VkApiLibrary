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
            Fields = new string[] 
            {
                ApiField.Photo50,
                ApiField.LastOnline
            };
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
