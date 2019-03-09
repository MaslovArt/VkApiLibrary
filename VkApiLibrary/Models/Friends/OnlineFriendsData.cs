using Newtonsoft.Json;

namespace VkApiSDK.Models.Friends
{
    public class OnlineFriendsData
    {
        [JsonProperty("online")]
        public int[] OnlineIDs { get; set; }

        [JsonProperty("online_mobile")]
        public int[] OnlineMobileIDs { get; set; }
    }
}
