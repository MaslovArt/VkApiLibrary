﻿using Newtonsoft.Json;

namespace VkApiSDK.Users
{
    public class User : Peer
    {
        [JsonProperty("id")]
        public override string ID { get; set; }

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

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("bdate")]
        public string Bdate { get; set; }

    }
}
