using System;
using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Возвращает список бесед пользователя.
    /// </summary>
    public class GetConversations : VkApiMethod
    {
        private int count = 10,
                    offset = 0;

        public GetConversations(string AccessToken, string[] Fields = null, int Offset = 0, int Count = 10, string Filter = DialogFilter.All)
            :base(AccessToken, Fields)
        {
            VkApiMethodName = "messages.getConversations";
            this.Offset = Offset;
            this.Count = Count;
            this.Filter = Filter;
        }

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
        /// фильтр. DialogFIlters.
        /// </summary>
        public string Filter
        {
            get; set;
        }

        protected override string GetMethodApiParams()
        {
            return string.Format("&offset={0}&count={1}&filter={2}", offset,
                                                                     count,
                                                                     Filter);
        }
    }
}
