using Newtonsoft.Json;

namespace VkApiSDK.Messages.Attachments
{
    public class Attachment
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
