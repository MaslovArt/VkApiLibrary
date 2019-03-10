using Newtonsoft.Json;
using VkApiSDK.Models.Response;

namespace VkApiSDK.Models.Messages
{
    public class DialogsData : ArrayResponse<Dialog>
    {
        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }
    }
}
