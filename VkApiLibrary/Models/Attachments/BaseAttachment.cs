using Newtonsoft.Json;
using System;
using VkApiSDK.Utils;

namespace VkApiSDK.Models.Attachments
{
    public class BaseAttachment
    {
        protected VkDateTime date;

        public string Type { get; protected set; }

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("owner_id")]
        public int OwnerID { get; set; }

        [JsonProperty("date")]
        public string Date
        {
            get { return date.DayTimeOrDayMonthTime; }
            set
            {
                date = new VkDateTime(Convert.ToInt64(value));
            }
        }

        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        public override string ToString()
        {
            var toSendString = string.Format("{0}{1}_{2}", Type, OwnerID, ID);
            if (!string.IsNullOrEmpty(AccessKey))
                toSendString += "_" + AccessKey;

            return toSendString;
        }
    }
}
