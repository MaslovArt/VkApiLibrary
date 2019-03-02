using Newtonsoft.Json;
using System;
using VkApiSDK.Utils;

namespace VkApiSDK
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class Dialog : Peer
    {
        private string _id;

        [JsonProperty("conversation.peer.type")]
        public override string Type { get; set; }

        [JsonProperty("conversation.peer.id")]
        public override string ID
        {
            get { return _id; }
            set
            {
                if (value.Length == 10)
                    _id = ((Convert.ToInt32(value)) - 2000000000).ToString();
                else
                    _id = value;
            }
        }

        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }

        [JsonProperty("conversation.chat_settings.title")]
        public string Title { get; set; }

        [JsonProperty("last_message")]
        public Message LastMessage { get; set; }

        [JsonProperty("conversation.can_write.allowed")]
        public bool CanWrite { get; set; }

        [JsonProperty("conversation.chat_settings.photo.photo_50")]
        public string Avatar { get; set; }
    }
}
