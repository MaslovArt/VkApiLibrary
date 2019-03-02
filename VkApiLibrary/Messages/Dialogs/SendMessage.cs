using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Requests;
using VkApiSDK.Messages.Attachments;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Отправляет сообщение.
    /// </summary>
    public class SendMessage : VkApiMethod
    {
        public SendMessage(string AccessToken, string UserID, string Message, string Attachments, string[] ForwardMessageIDs = null, string PeerID = "")
            :base(AccessToken)
        {
            VkApiMethodName = "messages.send";
            this.UserID = UserID;
            this.PeerID = PeerID;
            this.Message = Message;
            this.Attachments = Attachments;
            this.ForwardMessageIDs = ForwardMessageIDs ?? new string[] { };
        }

        /// <summary>
        /// Идентификатор пользователя, которому отправляется сообщение.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Идентификатор назначения. 
        /// </summary>
        public string PeerID { get; set; }

        private int RandomID
        {
            get { return (new Random()).Next(0, int.MaxValue); }
        }

        /// <summary>
        /// Текст личного сообщения. Обязательный параметр, если не задан параметр attachment. 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Медиавложения к личному сообщению, перечисленные через запятую.
        /// </summary>
        public string Attachments { get; set; }

        /// <summary>
        /// идентификаторы пересылаемых сообщений, перечисленные через запятую. Перечисленные сообщения отправителя будут 
        /// отображаться в теле письма у получателя. Не более 100 значений на верхнем уровне, максимальный уровень 
        /// вложенности: 45, максимальное количество пересылаемых сообщений 500
        /// </summary>
        public string[] ForwardMessageIDs { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&user_id={0}&peer_id={1}&message={2}&attachment={3}&forward_messages={4}&random_id={5}", UserID,
                                                                                                                           PeerID,
                                                                                                                           Message,
                                                                                                                           Attachments,
                                                                                                                           ArrayToString(ForwardMessageIDs),
                                                                                                                           RandomID);
        }
    }
}
