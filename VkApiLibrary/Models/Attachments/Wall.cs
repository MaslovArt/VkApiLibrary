using Newtonsoft.Json;

namespace VkApiSDK.Models.Attachments
{
    public class Wall : BaseAttachment
    {
        [JsonProperty("marked_as_ads")]
        public bool MarkedAsAds { get; set; }

        [JsonProperty("from_id")]
        public int FromID { get; set; }

        [JsonProperty("to_id")]
        public int ToID { get; set; }

        [JsonProperty("post_type")]
        public string PostType { get; set; }

        [JsonProperty("photo")]
        public Photo[] Photos { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}_{2}", AttachmentType.Wall, OwnerID, ID);
        }
    }
}
