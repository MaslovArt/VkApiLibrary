using Newtonsoft.Json;
using VkApiSDK.Utils;

namespace VkApiSDK.Messages.Attachments
{
    public class Picture : BaseAttachment
    {
        [JsonProperty("user_id")]
        public string UserID { get; set; }

        [JsonProperty("sizes")]
        public Image[] Photos { get; set; }
    }
}
