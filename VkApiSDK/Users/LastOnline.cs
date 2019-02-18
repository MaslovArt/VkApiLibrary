using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Users
{
    public class LastOnline
    {
        private DateTime date;

        [JsonProperty("time")]
        public string Time
        {
            get
            {
                return date.ToShortDateString();
            }
            set
            {
                date = new DateTime(Convert.ToInt64(value));
            }
        }

        [JsonProperty("platform")]
        public int Platform { get; set; }
    }
}
