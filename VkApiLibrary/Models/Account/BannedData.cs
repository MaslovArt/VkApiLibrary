using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Models.Account
{
    public class BannedData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public int[] Items { get; set; }

        [JsonProperty("profiles")]
        public User[] Profiles { get; set; }
    }
}
