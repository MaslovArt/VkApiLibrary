using Newtonsoft.Json;

namespace VkApiSDK.Messages.Dialogs
{
    public class Photos
    {
        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }
        [JsonProperty("photo_200")]
        public string Photo200 { get; set; }
    }
}
