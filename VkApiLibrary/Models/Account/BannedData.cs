using Newtonsoft.Json;

namespace VkApiSDK.Models.Account
{
    public class BannedData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public int[] Items { get; set; }

        [JsonProperty("profiles")]
        public User[] Profiles { get; set; }
    }
}
