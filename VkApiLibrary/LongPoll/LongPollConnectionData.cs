using Newtonsoft.Json;

namespace VkApiSDK.LongPoll
{
    public class LongPollConnectionData
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("ts")]
        public int Ts { get; set; }
    }
}
