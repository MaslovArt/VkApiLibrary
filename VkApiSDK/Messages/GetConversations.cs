using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
{
    public class GetConversations : IVkApiMethod
    {
        private string   apiUri = "https://api.vk.com/method/messages.getConversations?access_token={0}&offset={1}&count={2}&filter={3}&v=5.92";
        private string[] availableFilters = new string[] { "all" , "unread", "important", "unanswered" };
        private int      count = 10,
                         offset = 0;

        public GetConversations(string AccessToken)
        {
            this.AccessToken = AccessToken;
        }

        public string AccessToken { get; set; }

        /// <summary>
        /// Cмещение, необходимое для выборки определенного подмножества результатов.
        /// </summary>
        public int Offset
        {
            get { return offset; }
            set
            {
                if (value >= 0)
                    offset = value;
                else
                    throw new ArgumentException("Значение не может быть отрицательным.");
            }
        }
        /// <summary>
        /// Максимальное число результатов, которые нужно получить. 
        /// </summary>
        public int Count
        {
            get { return count; }
            set
            {
                if (value > 0 && value <= 200)
                    count = value;
                else
                    throw new ArgumentException("Значение не может быть отрицательным и больше 200.");
            }
        }
        /// <summary>
        /// фильтр.
        /// </summary>
        public Filters Filter
        {
            get; set;
        } = Filters.All;

        /// <summary>
        /// Изменяет смещение на число элементов в запросе.
        /// </summary>
        public void Next()
        {
            Offset += count;
        }

        public string GetRequestString()
        {
            return string.Format(apiUri, AccessToken, offset, count, availableFilters[(int)Filter]);
        }
    }
}
