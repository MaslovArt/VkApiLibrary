using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
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
