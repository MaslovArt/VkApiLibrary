using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Utils;

namespace VkApiSDK.Messages
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class TestDialog
    {
        [JsonProperty("conversation.peer.type")]
        public string Type { get; set; }

        [JsonProperty("conversation.peer.id")]
        public string ID { get; set; }

        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }

        [JsonProperty("chat_settings.title")]
        public string Title { get; set; }

        [JsonProperty("last_message")]
        public Message Message { get; set; }

        [JsonProperty("last_message")]
        public bool CanWrite { get; set; }
    }
}
