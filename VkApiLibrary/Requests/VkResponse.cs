using Newtonsoft.Json;

namespace VkApiSDK.Requests
{
    public class VkResponse<T> : IVkResponse
    {
        [JsonProperty("response")]
        public T Response { get; set; }

        public bool IsResultNull()
        {
            return Response == null;
        }
    }
}
