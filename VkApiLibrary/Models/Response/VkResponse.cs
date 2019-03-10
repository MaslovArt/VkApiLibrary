using Newtonsoft.Json;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Models.Response
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
