using System;
using System.Collections.Generic;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Messages.Methods
{
    /// <summary>
    /// Помечает сообщения как важные либо снимает отметку.
    /// </summary>
    public class MarkAsImportant : VkApiMethod
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>MarkAsImportant</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="MessageIDs">Список идентификаторов сообщений, которые необходимо пометить</param>
        /// <param name="Important">Сообщения необходимо пометить, как важные</param>
        public MarkAsImportant(string AccessToken, IEnumerable<int> MessageIDs, bool Important)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.markAsImportant";
            this.MessageIDs = MessageIDs;
            this.Important = Important;
        }

        /// <summary>
        /// Список идентификаторов сообщений, которые необходимо пометить
        /// </summary>
        public IEnumerable<int> MessageIDs { get; set; }

        /// <summary>
        /// Сообщения необходимо пометить, как важные
        /// </summary>
        public bool Important { get; set; }

        protected override string GetMethodApiParams()
        {
            return $"&message_ids={ArrayToString(MessageIDs)}&important={Convert.ToInt32(Important)}";
        }
    }
}
