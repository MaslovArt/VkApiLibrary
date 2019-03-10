using Newtonsoft.Json;
using VkApiSDK.Requests;

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
