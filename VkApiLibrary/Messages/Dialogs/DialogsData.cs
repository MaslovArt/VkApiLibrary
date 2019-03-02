using Newtonsoft.Json;

namespace VkApiSDK.Messages.Dialogs
{
    public class DialogsData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public Dialog[] Dialogs { get; set; }

        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }
    }
}
