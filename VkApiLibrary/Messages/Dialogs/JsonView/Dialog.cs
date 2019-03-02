using Newtonsoft.Json;

namespace VkApiSDK.Messages.Dialogs
{
    public class Dialog
    {
        [JsonProperty("conversation")]
        public Conversation Conversation { get; set; }

        [JsonProperty("last_message")]
        public Message Message { get; set; }
    }
}
