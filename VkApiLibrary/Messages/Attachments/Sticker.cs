using Newtonsoft.Json;

namespace VkApiSDK.Messages.Attachments
{
    public class Sticker
    {
        [JsonProperty("product_id")]
        public string ProductID { get; set; }

        [JsonProperty("sticker_id")]
        public string StickerID { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }
    }
}
