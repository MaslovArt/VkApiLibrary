﻿using Newtonsoft.Json;
using System;
using VkApiSDK.Utils;
using VkApiSDK.Messages.Attachments;

namespace VkApiSDK.Messages
{
    public class Message
    {
        private VkDateTime data;

        [JsonProperty("date")]
        public string Date
        {
            get { return data.DayTimeOrDayMonthTime; }
            set
            {
                data = new VkDateTime(Convert.ToInt64(value));
            }
        }

        [JsonProperty("from_id")]
        public int FromID { get; set; }

        [JsonProperty("peer_id")]
        public int PeerID { get; set; }

        [JsonProperty("out")]
        public int Out { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("fwd_messages")]
        public Message[] ForwardMessages { get; set; }

        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }
    }
}
