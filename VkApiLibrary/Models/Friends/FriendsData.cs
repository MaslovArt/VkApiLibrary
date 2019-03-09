using Newtonsoft.Json;

namespace VkApiSDK.Models.Friends
{
    public class FriendsData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public User[] Friends { get; set; }
    }
}
