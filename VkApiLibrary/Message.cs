using Newtonsoft.Json;
using System;
using VkApiSDK.Utils;
using VkApiSDK.Messages.Attachments;

namespace VkApiSDK
{
    public class Message
    {
        private VkDateTime data;

        [JsonProperty("id")]
        public string ID { get; set; }

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
        public string FromID { get; set; }

        [JsonProperty("peer_id")]
        public string PeerID { get; set; }

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
