using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace VkApiSDK
{
    public class VkAutharization
    {
        public const string APP_ID = "6865053",
                            APP_SecretKey = "lifwQ9ujqtJMnTNauL90",
                            SCOPE = "messages,friends,offline";
        private const string AUTH_URL = "https://oauth.vk.com/access_token?client_id={0}&client_secret={1}&redirect_uri=https://oauth.vk.com/blank.html&code={2},";

        private string auth_token;
        private AuthData AuthData;
        private HttpClient client;

        public VkAutharization(string auth_token)
        {
            this.auth_token = auth_token;
            client = new HttpClient();
        }

        public AuthData AuthdData
        {
            get { return AuthData; }
        }
            
        public async Task<AuthData> AuthAsync()
        {
            var responseString = await client.GetStringAsync(String.Format(AUTH_URL, APP_ID, APP_SecretKey, auth_token));
            AuthData = JsonConvert.DeserializeObject<AuthData>(responseString);
            return AuthData;
        }
    }
}
