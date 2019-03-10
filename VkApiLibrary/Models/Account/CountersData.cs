using Newtonsoft.Json;

namespace VkApiSDK.Models.Account
{
    public class CountersData
    {
        [JsonProperty("friends")]
        public int Friends { get; set; }

        [JsonProperty("friends_suggestions")]
        public int FriendsSuggestions { get; set; }

        [JsonProperty("messages")]
        public int Messages { get; set; }
    }
}
