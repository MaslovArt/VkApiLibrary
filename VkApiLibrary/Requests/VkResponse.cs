using Newtonsoft.Json;
using VkApiSDK.Abstraction;

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
