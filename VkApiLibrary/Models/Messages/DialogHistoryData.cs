using Newtonsoft.Json;
using VkApiSDK.Models;

namespace VkApiSDK.Model.Messages
{
    public class DialogHistoryData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public VkMessage[] Messages { get; set; }
    }
}
