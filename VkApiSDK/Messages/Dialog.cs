using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
{
    public class Dialog
    {
        [JsonProperty("conversation")]
        public Conversation Conversation { get; set; }

        [JsonProperty("last_message")]
        public Message Message { get; set; }
    }
}
