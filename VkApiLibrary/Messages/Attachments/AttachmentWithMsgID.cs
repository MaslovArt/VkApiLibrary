using Newtonsoft.Json;

namespace VkApiSDK.Messages.Attachments
{
    public class AttachmentWithMsgID
    {
        [JsonProperty("message_id")]
        public string MessageID { get; set; }

        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }
    }
}
