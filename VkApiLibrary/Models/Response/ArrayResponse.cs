using Newtonsoft.Json;

namespace VkApiSDK.Models.Response
{
    public class ArrayResponse<T>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public T[] Items { get; set; }
    }
}
