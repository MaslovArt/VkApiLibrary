using Newtonsoft.Json;

namespace VkApiSDK.Models.Attachments
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

        public override string ToString()
        {
            return string.Format("{0}{1}_{2}", AttachmentType.Audio, OwnerID, ID);
        }
    }
}
