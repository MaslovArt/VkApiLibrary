using System.Collections.Generic;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Messages.Methods
{
    /// <summary>
    /// Возвращает информацию о беседе.
    /// </summary>
    public class GetChat : VkApiMethod
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="ChatID">Идентификатор беседы.</param>
        /// <param name="Fields">Список дополнительных полей профилей, которые необходимо вернуть.</param>
        public GetChat(string AccessToken, int ChatID, IEnumerable<string> Fields = null)
            :base(AccessToken, Fields)
        {
            VkApiMethodName = "messages.getChat";
            this.ChatID = ChatID;
        }

        /// <summary>
        /// Идентификатор беседы. 
        /// </summary>
        public int ChatID { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&chat_id={0}", ChatID);
        }
    }
}
