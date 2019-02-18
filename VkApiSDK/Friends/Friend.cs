using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Users;

namespace VkApiSDK.Friends
{
    public class Friend : User
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("online")]
        public bool Online { get; set; }
    }
}
