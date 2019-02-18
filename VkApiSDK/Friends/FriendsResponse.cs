using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Friends
{
    public class FriendsResponse : IVkResponse
    {
        [JsonProperty("response")]
        public FriendsData FriendsData { get; set; }

        public bool ChechIfResponseNull()
        {
            return FriendsData == null;
        }
    }
}
