using System;

namespace VkApiSDK.Utils
{
    public class VkDateTime
    {
        private DateTime unixEpoch = new DateTime(1970, 1, 1, 3, 0, 0, 0, DateTimeKind.Utc);
        private DateTime dateTime;
        private long timestamp;

        public VkDateTime(long unixTimestamp)
        {
            timestamp = unixTimestamp;
            dateTime = unixEpoch.AddSeconds(unixTimestamp);
        }

        public long TimeUnix
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public string DayTimeOrDayMonthTime
        {
            get
            {
                return getTime();
            }
        }

        private string getTime()
        {
            var diff = DateTime.Now - dateTime;
            string result = "";
            if (diff.Days <= 2)
            {
                switch (diff.Days)
                {
                    case 0: result += "Сегодня"; break;
                    case 1: result += "Вчера"; break;
                    case 2: result += "Позавчера"; break;
                }
            }
            else
            {
                result = dateTime.Day + " " + dateTime.ToString("MMMM");
            }
            result += " в " + dateTime.ToString();

            return result;
        }
    }
}
