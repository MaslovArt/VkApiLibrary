using System;

namespace VkApiSDK.Utils
{
    public class VkDateTime
    {
        private DateTime unixEpoch;
        private DateTime dateTime;
        private long timestamp;

        public VkDateTime(long unixTimestamp)
        {
            var utcOffset = TimeZoneInfo.Local.BaseUtcOffset.Hours;
            unixEpoch = new DateTime(1970, 1, 1, utcOffset, 0, 0, 0, DateTimeKind.Utc);
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
            var diff = DateTime.Now.Day - dateTime.Day;
            string result = "";
            if (diff <= 2)
            {
                switch (diff)
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
            result += " в " + dateTime.Hour + ":" + dateTime.Minute;

            return result;
        }
    }
}
