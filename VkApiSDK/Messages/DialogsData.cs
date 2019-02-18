using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
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
