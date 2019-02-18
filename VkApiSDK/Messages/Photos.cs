using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
{
    public class Photos
    {
        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }
        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }
    }
}
