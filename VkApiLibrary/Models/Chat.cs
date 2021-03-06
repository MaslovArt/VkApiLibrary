﻿using Newtonsoft.Json;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Models
{
    public class Chat : Peer
    {
        [JsonProperty("id")]
        public override int ID { get; set; }

        [JsonProperty("type")]
        public override string Type { get; set; } = "chat";

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("admin_id")]
        public int AdminID { get; set; }

        [JsonProperty("users")]
        public User[] UserIDs { get; set; }

        [JsonProperty("members_count")]
        public int Count { get; set; }

        [JsonProperty("photo_50")]
        public string Avatar { get; set; }
    }
}
