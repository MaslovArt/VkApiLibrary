using Newtonsoft.Json;
using VkApiSDK.Models.Response;

namespace VkApiSDK.Models.Account
{
    public class BannedData : ArrayResponse<int>
    {
        [JsonProperty("profiles")]
        public User[] Profiles { get; set; }
    }
}
