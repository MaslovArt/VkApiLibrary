using Newtonsoft.Json;

namespace VkApiSDK.Models.Attachments
{
    public class Photo : BaseAttachment
    {
        public Photo()
        {
            Type = AttachmentType.Photo;
        }

        [JsonProperty("user_id")]
        public string UserID { get; set; }

        [JsonProperty("sizes")]
        public Image[] Photos { get; set; }
    }
}
