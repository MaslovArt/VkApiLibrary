using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Users
{
    class UserResponse : IVkResponse
    {
        [JsonProperty("response")]
        public User[] Users { get; set; }

        public bool ChechIfResponseNull()
        {
            return Users == null;
        }
    }
}
