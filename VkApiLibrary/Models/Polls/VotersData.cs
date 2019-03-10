using Newtonsoft.Json;
using VkApiSDK.Models.Response;

namespace VkApiSDK.Models.Polls
{
    public class VotersData
    {
        [JsonProperty("answer_id")]
        public int AnswerID { get; set; }

        [JsonProperty("users")]
        public ArrayResponse<int> Users { get; set; }
    }
}
