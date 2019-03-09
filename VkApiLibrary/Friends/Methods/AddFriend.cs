using System;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Friends.Methods
{
    /// <summary>
    /// Одобряет или создает заявку на добавление в друзья.
    /// </summary>
    public class AddFriend : VkApiMethod
    {
        private string text;

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>AddFriend</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="UserID">Идентификатор пользователя, которому необходимо отправить заявку, 
        /// либо заявку от которого необходимо одобрить.</param>
        /// <param name="Follow">Необходимость отклонить входящую заявку.</param>
        /// <param name="Text">Текст сопроводительного сообщения для заявки на добавление в друзья. </param>
        public AddFriend(string AccessToken, int UserID, bool Follow, string Text = "")
            :base(AccessToken)
        {
            VkApiMethodName = "friends.add";
            this.UserID = UserID;
            this.Text = Text;
            this.Follow = Follow;
        }

        /// <summary>
        /// Идентификатор пользователя, которому необходимо отправить заявку, либо заявку от которого необходимо одобрить.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Текст сопроводительного сообщения для заявки на добавление в друзья. 
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string Text
        {
            get { return text; }
            set
            {
                if (value.Length > 500)
                    throw new ArgumentException("Максимальная длина сообщения — 500 символов.");
                text = value;
            }
        }

        /// <summary>
        /// Необходимость отклонить входящую заявку.
        /// </summary>
        public bool Follow { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&user_id={0}&text={1}&follow={2}", UserID, 
                                                                     Text, 
                                                                     Follow ? 1 : 0);
        }
    }
}
