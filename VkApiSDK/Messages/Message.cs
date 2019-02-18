using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
{
    public class Message
    {
        private DateTime data;

        [JsonProperty("date")]
        public string Data
        {
            get { return data.ToShortDateString(); }
            set
            {
                data = new DateTime(Convert.ToInt64(value));
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

        [JsonProperty("body")]
        private string Text2
        {
            get { return Text; }
            set { Text = value; }
        }
    }
}
