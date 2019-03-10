using System;
using System.Collections.Generic;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Messages.Methods
{
    /// <summary>
    /// Отправляет сообщение.
    /// </summary>
    public class SendMessage : VkApiMethod
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="PeerID"></param>
        /// <param name="Message"></param>
        /// <param name="Attachments"></param>
        /// <param name="ReplyTo">Идентификатор сообщения, на которое требуется ответить</param>
        /// <param name="ForwardMessageIDs"></param>
        public SendMessage(string AccessToken, int PeerID, string Message, string Attachments = "", int? ReplyTo = null, IEnumerable<int> ForwardMessageIDs = null)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.send";
            this.PeerID = PeerID;
            this.Message = Message;
            this.Attachments = Attachments;
            this.ForwardMessageIDs = ForwardMessageIDs ?? new int[] { };
            this.ReplyTo = ReplyTo;
        }

        /// <summary>
        /// Идентификатор назначения. 
        /// </summary>
        public int PeerID { get; set; }

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
        /// Идентификатор сообщения, на которое требуется ответить
        /// </summary>
        public int? ReplyTo { get; set; }

        /// <summary>
        /// идентификаторы пересылаемых сообщений, перечисленные через запятую. Перечисленные сообщения отправителя будут 
        /// отображаться в теле письма у получателя. Не более 100 значений на верхнем уровне, максимальный уровень 
        /// вложенности: 45, максимальное количество пересылаемых сообщений 500
        /// </summary>
        public IEnumerable<int> ForwardMessageIDs { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&peer_id={0}&message={1}&attachment={2}&forward_messages={3}&random_id={4}&reply_to={5}", PeerID,
                                                                                                                            Message,
                                                                                                                            Attachments,
                                                                                                                            ArrayToString(ForwardMessageIDs),
                                                                                                                            RandomID,
                                                                                                                            ReplyTo);
        }
    }
}
