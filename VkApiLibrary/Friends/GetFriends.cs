using System;
using VkApiSDK.Requests;
using VkApiSDK.Requests.Attributes;

namespace VkApiSDK.Friends
{
    /// <summary>
    /// Возвращает список идентификаторов друзей пользователя или расширенную информацию о друзьях пользователя 
    /// (при использовании параметра fields)
    /// </summary>
    public class GetFriends : VkApiMethod
    {
        private int count = 5000,
                    offset = 0;

        public GetFriends(string AccessToken, int UserID, string[] Fields = null, string Order = FriendOrder.Hints, int Count = 5000, int Offset = 0)
            :base(AccessToken, Fields)
        {
            VkApiMethodName = "friends.get";
            this.UserID = UserID;
            this.Order = Order;
            this.Count = Count;
            this.Offset = Offset;
        }

        /// <summary>
        /// Идентификатор пользователя, для которого необходимо получить список друзей. 
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Порядок, в котором нужно вернуть список друзей. 
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// Количество друзей, которое нужно вернуть.
        /// </summary>
        public int Count
        {
            get { return count; }
            set
            {
                if (value > 0 && value <= 5000)
                    count = value;
                else
                    throw new ArgumentException("Значение не может быть отрицательным и больше 5000.");
            }
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

        protected override string GetMethodApiParams()
        {
             return string.Format("&user_id={0}&order={1}&count={2}&offset={3}", UserID,
                                                                                 Order,
                                                                                 Count,
                                                                                 Offset);
        }
    }
}
