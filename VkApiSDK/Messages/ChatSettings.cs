using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
{
    public class ChatSettings
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("photo")]
        public Photos Photos { get; set; }
    }
}
