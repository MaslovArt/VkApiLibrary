using Newtonsoft.Json;

namespace VkApiSDK.Messages.Dialogs
{
    public class Peer
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }
    }
}
