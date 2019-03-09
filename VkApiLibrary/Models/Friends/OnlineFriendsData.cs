using Newtonsoft.Json;

namespace VkApiSDK.Models.Friends
{
    public class OnlineFriendsData
    {
        [JsonProperty("online")]
        public string[] OnlineIDs { get; set; }

        [JsonProperty("online_mobile")]
        public string[] OnlineMobileIDs { get; set; }
    }
}
