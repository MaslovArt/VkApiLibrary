using Newtonsoft.Json;

namespace VkApiSDK.Models.Attachments
{
    public class VoteAnswer
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("votes")]
        public int VotesCounter { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }
    }
}
