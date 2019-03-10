using Newtonsoft.Json;

namespace VkApiSDK.Requests
{
    public class ArrayResponse<T>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public T[] Friends { get; set; }
    }
}
