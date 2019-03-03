using System;
using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Удаляет личные сообщения в беседе.
    /// </summary>
    public class DeleteConversation : VkApiMethod
    {
        private int _count;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="PeerID">Идентификатор назначения. </param>
        /// <param name="Offset">Начиная с какого сообщения нужно удалить переписку.</param>
        /// <param name="Count">Сколько сообщений нужно удалить.</param>
        public DeleteConversation(string AccessToken, string PeerID, int Offset = 0, int Count = 10000)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.deleteConversation";
            this.PeerID = PeerID;
            this.Count = Count;
            this.Offset = Offset;
        }

        /// <summary>
        /// Идентификатор назначения. 
        /// </summary>
        public string PeerID { get; set; }

        /// <summary>
        /// Начиная с какого сообщения нужно удалить переписку. 
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Сколько сообщений нужно удалить.
        /// </summary>
        /// <remarks>
        /// За один вызов нельзя удалить больше 10000 сообщений,
        /// </remarks>
        public int Count
        {
            get { return _count; }
            set
            {
                if (value > 10000)
                    throw new ArgumentException("Значение не может быть больше 10000");
                _count = value;
            }
        }

        protected override string GetMethodApiParams()
        {
            return string.Format("&peer_id={0}&offset={1}&count={2}", PeerID, 
                                                                      Offset, 
                                                                      Count);
        }
    }
}
