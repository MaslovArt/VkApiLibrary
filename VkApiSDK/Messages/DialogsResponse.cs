using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
{
    public class DialogsResponse : IVkResponse
    {
        [JsonProperty("response")]
        public DialogsData DialogsData { get; set; }

        public bool ChechIfResponseNull()
        {
            return DialogsData == null;
        }
    }
}
