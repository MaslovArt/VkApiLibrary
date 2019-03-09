using Newtonsoft.Json;

namespace VkApiSDK.Models.Errors
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
