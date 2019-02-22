﻿using Newtonsoft.Json;

namespace VkApiSDK.Errors
{
    public class Error
    {
        [JsonProperty("error_code")]
        public int Code { get; set; }

        [JsonProperty("error_msg")]
        public string Message { get; set; }
    }
}
