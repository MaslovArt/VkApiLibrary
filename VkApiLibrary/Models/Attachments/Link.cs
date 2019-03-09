using Newtonsoft.Json;

namespace VkApiSDK.Models.Attachments
{
    public class Link
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("photo")]
        public Picture Photos { get; set; }
    }
}
