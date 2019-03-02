using Newtonsoft.Json;

namespace VkApiSDK.Messages
{
    public class Chat : Peer
    {
        [JsonProperty("id")]
        public override string ID { get; set; }

        [JsonProperty("type")]
        public override string Type { get; set; } = "chat";

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("admin_id")]
        public string AdminID { get; set; }

        [JsonProperty("users")]
        public User[] UserIDs { get; set; }

        [JsonProperty("members_count")]
        public int Count { get; set; }

        [JsonProperty("photo_50")]
        public string Avatar { get; set; }
    }
}
