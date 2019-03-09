using Newtonsoft.Json;
using VkApiSDK.Abstraction;
using VkApiSDK.Utils;

namespace VkApiSDK.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class Dialog : Peer
    {
        private int _id;

        [JsonProperty("conversation.peer.type")]
        public override string Type { get; set; }

        [JsonProperty("conversation.peer.id")]
        public override int ID
        {
            get { return _id; }
            set
            {
                if (value > 2000000000)
                    _id = value - 2000000000;
                else
                    _id = value;
            }
        }

        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }

        [JsonProperty("conversation.chat_settings.title")]
        public string Title { get; set; }

        [JsonProperty("last_message")]
        public VkMessage LastMessage { get; set; }

        [JsonProperty("conversation.can_write.allowed")]
        public bool CanWrite { get; set; }

        [JsonProperty("conversation.chat_settings.photo.photo_50")]
        public string Avatar { get; set; }
    }
}
