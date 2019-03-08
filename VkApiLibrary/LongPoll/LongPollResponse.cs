using Newtonsoft.Json;
using System.Collections.Generic;

namespace VkApiSDK.LongPoll
{
    public class LongPollResponse
    {
        [JsonProperty("failed")]
        public int ErrorCode { get; set; }

        [JsonProperty("ts")]
        public int Ts { get; set; }

        [JsonProperty("updates")]
        public object[][] Updates { get; set; }
    }
}
