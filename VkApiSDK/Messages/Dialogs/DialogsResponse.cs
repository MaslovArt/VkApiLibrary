using Newtonsoft.Json;

namespace VkApiSDK.Messages.Dialogs
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
