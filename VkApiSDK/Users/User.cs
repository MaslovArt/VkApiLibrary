using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Users
{
    public class User
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [JsonProperty("photo_50")]
        public string Avatar { get; set; }

        [JsonProperty("last_seen")]
        public LastOnline LastOnline { get; set; }

        [JsonProperty("online")]
        public bool Online { get; set; }
    }
}
