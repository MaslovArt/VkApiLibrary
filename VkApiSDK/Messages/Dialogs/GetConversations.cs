using System;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Возвращает список бесед пользователя.
    /// </summary>
    public class GetConversations : VkApiMethod
    {
        private int count = 10,
                    offset = 0;

        public GetConversations(string AccessToken)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.getConversations";
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
        } = DialogFilter.All;

        /// <summary>
        /// Устанавливает смещение для получения следующего набора диалогов.
        /// </summary>
        public void Next()
        {
            Offset += count;
        }

        protected override string GetMethodApiParams()
        {
            return string.Format("&offset={0}&count={1}&filter={2}", offset,
                                                                     count,
                                                                     Filter);
        }
    }
}
