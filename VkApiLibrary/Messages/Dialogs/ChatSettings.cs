using Newtonsoft.Json;

namespace VkApiSDK.Messages.Dialogs
{
    public class ChatSettings
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("photo")]
        public Photos Photos { get; set; }
    }
}
