using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Изменяет статус набора текста пользователем в диалоге.
    /// </summary>
    public class SetActivity : VkApiMethod
    {
        public SetActivity(string AccessToken, string UserID, string Type = ActivityType.Typing)
            : base(AccessToken)
        {
            VkApiMethodName = "messages.setActivity";
            this.UserID = UserID;
            this.Type = Type;
        }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Тип сообщения.
        /// </summary>
        public string Type { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&user_id={0}&type={1}", UserID, 
                                                          Type);
        }
    }

    /// <summary>
    /// Тип набираемого сообщения.
    /// </summary>
    public static class ActivityType
    {
        public const string Typing = "typing",
                            Audiomessage = "audiomessage";
    }
}
