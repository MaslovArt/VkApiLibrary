using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Friends
{
    class GetFriends : IVkApiMethod
    {
        private string apiUri = "https://api.vk.com/method/friends.get?access_token={0}&user_id={1}&order={2}&count={3}&offset={4}&fields={5}&v=5.92";
        private int count = 5000,
                    offset = 0;
        private string[] order = new string[] { "hints", "random", "mobile", "name"};

        public GetFriends(string AccessToken)
        {
            this.AccessToken = AccessToken;
        }

        public string AccessToken { get; set; }

        /// <summary>
        /// Идентификатор пользователя, для которого необходимо получить список друзей. 
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Порядок, в котором нужно вернуть список друзей. 
        /// </summary>
        public FriendOrder Order { get; set; } = FriendOrder.hints;

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

        /// <summary>
        /// список дополнительных полей, которые необходимо вернуть. 
        /// Доступные значения: nickname, domain, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities
        /// список слов, разделенных через запятую
        /// </summary>
        public string Fields
        {
            get; set;
        } = "photo_50,online,last_seen";

        public string GetRequestString()
        {
            return string.Format(apiUri, AccessToken, UserID, order[(int)Order], Count, Offset, Fields);
        }
    }
}
