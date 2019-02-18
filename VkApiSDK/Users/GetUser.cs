using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Users
{
    class GetUser : IVkApiMethod
    {
        private string apiUri = "https://api.vk.com/method/users.get?access_token={0}&user_ids={1}&fields={2}&v=5.92";

        public GetUser(string AccessToken)
        {
            this.AccessToken = AccessToken;
        }

        public string AccessToken { get; set; }

        /// <summary>
        /// Идентификаторы пользователей или их короткие имена.
        /// </summary>
        public string[] UserIDs { get; set; }

        /// <summary>
        /// Cписок дополнительных полей профилей, которые необходимо вернуть.
        /// </summary>
        public string Fields { get; set; } = "photo_50";

        public string GetRequestString()
        {
            return string.Format(apiUri, AccessToken, userIDsArrayToString(), Fields);
        }

        /// <summary>
        /// Преобразует массив строк в одну строку.
        /// </summary>
        /// <returns></returns>
        private string userIDsArrayToString()
        {
            var result = "";
            foreach (var id in UserIDs)
                result += id + ",";
            result = result.Remove(result.Length - 1, 1);

            return result;
        }
    }
}
