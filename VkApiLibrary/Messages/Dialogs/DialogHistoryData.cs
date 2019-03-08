using Newtonsoft.Json;

namespace VkApiSDK.Messages.Dialogs
{
    public class DialogHistoryData
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public VkMessage[] Messages { get; set; }
    }
}
