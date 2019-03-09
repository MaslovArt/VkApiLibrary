using Newtonsoft.Json;

namespace VkApiSDK.Models.Attachments
{
    public class Picture : BaseAttachment
    {
        [JsonProperty("user_id")]
        public string UserID { get; set; }

        [JsonProperty("sizes")]
        public Image[] Photos { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}_{2}", AttachmentType.Photo, OwnerID, ID);
        }
    }
}
