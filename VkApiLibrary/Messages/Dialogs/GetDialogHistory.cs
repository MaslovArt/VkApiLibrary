using System;
using System.Linq;
using VkApiSDK.Requests;
using VkApiSDK.Requests.Attributes;

namespace VkApiSDK.Messages
{
    /// <summary>
    /// Возвращает историю сообщений для указанного диалога.
    /// </summary>
    public class GetDialogHistory : VkApiMethod
    {
        private int count = 10,
                    offset = 0;

        public GetDialogHistory(string AccessToken, string UserID, int Offset = 0, int Count = 10, int StartMessageID = -1, string[] Fields = null)
            :base(AccessToken, Fields)
        {
            VkApiMethodName = "messages.getHistory";
            this.UserID = UserID;
            this.Offset = Offset;
            this.Count = Count;
            this.StartMessageID = StartMessageID;
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
        /// Идентификатор пользователя, историю переписки с которым необходимо вернуть.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Если значение > 0, то это идентификатор сообщения, начиная с которого нужно вернуть историю переписки,
        /// если передано значение 0 то вернутся сообщения с самого начала переписки,
        /// если же передано значение -1, то к значению параметра offset прибавляется количество входящих непрочитанных
        /// сообщений в конце диалога
        /// </summary>
        public int StartMessageID { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&offset={0}&count={1}&user_id={2}&start_message_id={3}", Offset,
                                                                                           Count,
                                                                                           UserID,
                                                                                           StartMessageID);
        }
    }
}
