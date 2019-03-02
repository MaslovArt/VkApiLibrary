using Newtonsoft.Json;
using VkApiSDK.Utils;

namespace VkApiSDK.Messages.Attachments
{
    public class Audio : BaseAttachment
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("is_explicit")]
        public bool Is_explicit { get; set; }
    }
}
