using Newtonsoft.Json;

namespace VkApiSDK.Messages.Dialogs
{
    public class Conversation
    {
        [JsonProperty("peer")]
        public Peer Peer { get; set; }

        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }

        [JsonProperty("chat_settings")]
        public ChatSettings ChatSettings { get; set; }
    }
}
