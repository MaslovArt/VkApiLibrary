using Newtonsoft.Json;

namespace VkApiSDK.Models.Friends
{
    public class DeleteFriendData
    {
        [JsonProperty("success")]
        public int Success { get; set; }

        [JsonProperty("friend_deleted")]
        public int FriendDeleted { get; set; }

        [JsonProperty("out_request_deleted")]
        public int OutRequestDeleted { get; set; }

        [JsonProperty("in_request_deleted")]
        public int InRequestDeleted { get; set; }

        [JsonProperty("suggestion_deleted ")]
        public int SuggestionDeleted { get; set; }
    }
}
