using Newtonsoft.Json;
using System;
using VkApiSDK.Utils;

namespace VkApiSDK.Users
{
    public class LastOnline
    {
        private VkDateTime date;

        [JsonProperty("time")]
        public string Time
        {
            get
            {
                return date.DayTimeOrDayMonthTime;
            }
            set
            {
                date = new VkDateTime(Convert.ToInt64(value));
            }
        }

        [JsonProperty("platform")]
        public int Platform { get; set; }
    }
}
