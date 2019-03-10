using Newtonsoft.Json;
using System;
using VkApiSDK.Utils;

namespace VkApiSDK.Models.Attachments
{
    public class Poll : BaseAttachment
    {
        [JsonProperty("created")]
        public new string Date
        {
            get { return date.DayTimeOrDayMonthTime; }
            set
            {
                date = new VkDateTime(Convert.ToInt64(value));
            }
        }

        [JsonProperty("question")]
        public string QuestionText { get; set; }

        [JsonProperty("votes")]
        public int VotesCounter { get; set; }

        [JsonProperty("anonymous")]
        public bool Anonymous { get; set; }

        [JsonProperty("multiple")]
        public bool Multiple { get; set; }

        [JsonProperty("can_vote")]
        public bool CanVote { get; set; }

        [JsonProperty("answers")]
        public VoteAnswer[] Answers { get; set; }
    }
}
