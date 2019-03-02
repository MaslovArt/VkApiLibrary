using System.Collections.Generic;
using VkApiSDK.Requests;

namespace VkApiSDK.Users
{
    /// <summary>
    /// Возвращает расширенную информацию о пользователях.
    /// </summary>
    public class GetUsers : VkApiMethod
    {
        public GetUsers(string AccessToken, IEnumerable<string> UserIDs, IEnumerable<string> Fields = null)
            :base(AccessToken, Fields)
        {
            VkApiMethodName = "users.get";
            this.UserIDs = UserIDs;
        }

        /// <summary>
        /// Идентификаторы пользователей или их короткие имена.
        /// </summary>
        public IEnumerable<string> UserIDs { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&user_ids={0}", ArrayToString(UserIDs));
        }
    }
}
