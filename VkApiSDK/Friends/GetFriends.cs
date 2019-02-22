using System;

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

        public GetFriends(string AccessToken)
            :base(AccessToken)
        {
            VkApiMethodName = "friends.get";
            Fields = new string[]
            {
                ApiField.Photo50,
                ApiField.LastOnline,
                ApiField.IsOnline
            };
        }

        /// <summary>
        /// Идентификатор пользователя, для которого необходимо получить список друзей. 
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Порядок, в котором нужно вернуть список друзей. 
        /// </summary>
        public string Order { get; set; } = FriendOrder.Hints;

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
