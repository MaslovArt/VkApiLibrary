using System;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Friends.Methods
{
    /// <summary>
    /// Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
    /// </summary>
    public class DeleteFriend : VkApiMethod
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>DeleteFriend</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="UserID">Идентификатор пользователя, которого необходимо удалить из списка друзей,
        /// либо заявку от которого необходимо отклонить</param>
        public DeleteFriend(string AccessToken, int UserID)
            :base(AccessToken)
        {
            VkApiMethodName = "friends.delete";
            this.UserID = UserID;
        }

        /// <summary>
        /// Идентификатор пользователя, которого необходимо удалить из списка друзей,
        /// либо заявку от которого необходимо отклонить
        /// </summary>
        public int UserID { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&user_id={0}", UserID);
        }
    }
}
