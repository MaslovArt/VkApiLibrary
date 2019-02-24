using System;
using Newtonsoft.Json;

namespace VkApiSDK
{
    public class AuthData
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public string Expires { get; set; }

        [JsonProperty("user_id")]
        public string UserID { get; set; }

        public override string ToString()
        {
            return string.Format("Access Token = {0}, Expires = {1}, User ID = {2}", AccessToken,
                                                                                     Expires,
                                                                                     UserID);
        }
    }
}
