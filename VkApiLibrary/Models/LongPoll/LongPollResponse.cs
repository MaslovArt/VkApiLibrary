using Newtonsoft.Json;

namespace VkApiSDK.Models.LongPoll
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
