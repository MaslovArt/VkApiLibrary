using Newtonsoft.Json;
using VkApiSDK.Users;

namespace VkApiSDK.Friends
{
    public class FriendsData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public User[] Friends { get; set; }
    }
}
