using System;
using Newtonsoft.Json;
using VkApiSDK.Abstraction;
using VkApiSDK.Models.Errors;

namespace VkApiSDK.Models.Response
{
    public class VkResponse<T> : IVkResponse
    {
        [JsonProperty("response")]
        public T Response { get; set; }

        public Error Error { get; set; }

        public bool IsSucceed => Response != null;

        public void SetError(Error Error)
        {
            this.Error = Error;
        }
    }
}
