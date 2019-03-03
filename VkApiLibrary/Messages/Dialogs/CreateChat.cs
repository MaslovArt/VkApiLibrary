using System.Collections.Generic;
using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Создаёт беседу с несколькими участниками.
    /// </summary>
    public class CreateChat : VkApiMethod
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="Title">Название беседы.</param>
        /// <param name="UserIDs">Идентификаторы пользователей, которых нужно включить в мультидиалог.</param>
        public CreateChat(string AccessToken, string Title, IEnumerable<string> UserIDs)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.createChat";
            this.Title = Title;
            this.UserIDs = UserIDs;
        }

        /// <summary>
        /// Идентификаторы пользователей, которых нужно включить в мультидиалог.
        /// </summary>
        /// <remark>
        /// Должны быть в друзьях у текущего пользователя. 
        /// </remark>
        public string Title { get; set; }

        /// <summary>
        /// Название беседы. 
        /// </summary>
        public IEnumerable<string> UserIDs { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&title={0}&user_ids={1}", Title,
                                                            ArrayToString(UserIDs));
        }
    }
}
