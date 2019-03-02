using Newtonsoft.Json;

namespace VkApiSDK.Messages.Attachments
{
    public class Document : BaseAttachment
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
