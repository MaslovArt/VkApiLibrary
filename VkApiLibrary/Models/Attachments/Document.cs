using Newtonsoft.Json;

namespace VkApiSDK.Models.Attachments
{
    public class Document : BaseAttachment
    {
        public Document()
        {
            Type = AttachmentType.Doc;
        }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("type")]
        public string DocType { get; set; }
    }
}
