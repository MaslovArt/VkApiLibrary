using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK
{
    class VkResponse<T>
    {
        [JsonProperty("response")]
        public T Response { get; set; }
    }
}
