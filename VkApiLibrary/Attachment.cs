using Newtonsoft.Json;
using VkApiSDK.Messages.Attachments;

namespace VkApiSDK
{
    public class Attachment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("audio")]
        public Audio Audio { get; set; }

        [JsonProperty("doc")]
        public Document Doc { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("sticker")]
        public Sticker Sticker { get; set; }

        [JsonProperty("wall")]
        public Wall Wall { get; set; }

        [JsonProperty("photo")]
        public Picture Picture { get; set; }
    }
}
