﻿using Newtonsoft.Json;
using VkApiSDK.Utils;

namespace VkApiSDK.Messages.Attachments
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class AttachmentData
    {
        [JsonProperty("items")]
        public AttachmentWithMsgID[] Items { get; set; }

        [JsonProperty("next_from")]
        public string NextFrom { get; set; }
    }
}
