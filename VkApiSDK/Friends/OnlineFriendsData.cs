using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Friends
{
    public class OnlineFriendsData
    {
        [JsonProperty("online")]
        public string[] OnlineIDs { get; set; }

        [JsonProperty("online_mobile")]
        public string[] OnlineMobileIDs { get; set; }
    }
}
