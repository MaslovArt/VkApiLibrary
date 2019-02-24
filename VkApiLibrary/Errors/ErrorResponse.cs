using Newtonsoft.Json;

namespace VkApiSDK.Errors
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
