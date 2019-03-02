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
    public class Dialog : Peer
    {
        [JsonProperty("conversation.peer.type")]
        public string Type { get; set; }

        [JsonProperty("conversation.peer.id")]
        public override string ID { get; set; }

        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }

        [JsonProperty("conversation.chat_settings.title")]
        public string Title { get; set; }

        [JsonProperty("last_message")]
        public Message LastMessage { get; set; }

        [JsonProperty("conversation.can_write.allowed")]
        public bool CanWrite { get; set; }

        [JsonProperty("conversation.chat_settings.photo.photo_50")]
        public string Avatar { get; set; }
    }
}
