using Newtonsoft.Json;
using System;
using VkApiSDK.Utils;

namespace VkApiSDK.Models.Attachments
{
    public class BaseAttachment
    {
        private VkDateTime data;

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerID { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("date")]
        public string Date
        {
            get { return data.DayTimeOrDayMonthTime; }
            set
            {
                data = new VkDateTime(Convert.ToInt64(value));
            }
        }

        [JsonProperty("access_key")]
        public string AccessKey { get; set; }
    }
}
