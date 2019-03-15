using System;
using Newtonsoft.Json;
using VkApiSDK.Abstraction;
using VkApiSDK.Models.Errors;

namespace VkApiSDK.Models.LongPoll
{
    public class LongPollResponse : IVkResponse
    {
        [JsonProperty("failed")]
        public int ErrorCode { get; set; }

        [JsonProperty("ts")]
        public int Ts { get; set; }

        [JsonProperty("updates")]
        public object[][] Updates { get; set; }

        public bool IsSucceed => ErrorCode == 0;

        public void SetError(Error Error)
        {
            ErrorCode = Error.Code;
        }
    }
}
