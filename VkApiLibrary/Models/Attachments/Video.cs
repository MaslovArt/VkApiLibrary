using Newtonsoft.Json;

namespace VkApiSDK.Models.Attachments
{
    public class Video : BaseAttachment
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("photo_130")]
        public string Photo130 { get; set; }

        [JsonProperty("photo_320")]
        public string Photo320 { get; set; }

        [JsonProperty("photo_640")]
        public string Photo640 { get; set; }

        [JsonProperty("photo_800")]
        public string Photo800 { get; set; }

        [JsonProperty("photo_1280")]
        public string Photo1280 { get; set; }

        [JsonProperty("player")]
        public string PlayerUrl { get; set; }

        [JsonProperty("live")]
        public int Live { get; set; }
    }
}
