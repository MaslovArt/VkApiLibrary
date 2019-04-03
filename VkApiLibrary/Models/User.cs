using Newtonsoft.Json;
using VkApiSDK.Abstraction;
using VkApiSDK.Models.Users;
using VkApiSDK.Requests;
using VkApiSDK.Utils;

namespace VkApiSDK.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class User : Peer
    {
        [JsonProperty("id")]
        public override int ID { get; set; }

        public override string Type { get; set; } = "user";

        [JsonProperty(ExtraField.FirstName)]
        public string FirstName { get; set; }

        [JsonProperty(ExtraField.LastName)]
        public string LastName { get; set; }

        [JsonProperty(ExtraField.ScreenName)]
        public string PageName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }


        [JsonProperty(ExtraField.Photo50)]
        public string Avatar50 { get; set; }

        [JsonProperty(ExtraField.Photo100)]
        public string Avatar100 { get; set; }

        [JsonProperty(ExtraField.Photo200)]
        public string Avatar200 { get; set; }

        [JsonProperty(ExtraField.Photo400orig)]
        public string Avatar400 { get; set; }

        [JsonProperty(ExtraField.LastOnline)]
        public LastOnline LastOnline { get; set; }

        [JsonProperty(ExtraField.IsOnline)]
        public bool Online { get; set; }

        [JsonProperty(ExtraField.Status)]
        public string Status { get; set; }

        [JsonProperty(ExtraField.BirthDay)]
        public string Bdate { get; set; }

        [JsonProperty(ExtraField.Counters + ".friends")]
        public int FriendsCount { get; set; }

        [JsonProperty(ExtraField.Counters + ".followers")]
        public int FollowerCount { get; set; }
    }
}
