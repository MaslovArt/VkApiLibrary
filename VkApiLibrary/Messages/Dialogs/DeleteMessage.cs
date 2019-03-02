using System;
using VkApiSDK.Requests;

namespace VkApiSDK.Messages.Dialogs
{
    /// <summary>
    /// Удаляет сообщение.
    /// </summary>
    public class DeleteMessage : VkApiMethod
    {
        public DeleteMessage(string AccessToken, string[] MessageIDs, bool DeleteForAll = true)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.delete";
            this.MessageIDs = MessageIDs;
            this.DeleteForAll = DeleteForAll;
        }

        /// <summary>
        /// Cписок идентификаторов сообщений
        /// </summary>
        public string[] MessageIDs { get; set; }

        /// <summary>
        /// Cообщение нужно удалить для получателей (если с момента отправки сообщения прошло не более 24 часов ). 
        /// </summary>
        public bool DeleteForAll { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&message_ids={0}&delete_for_all={1}", ArrayToString(MessageIDs), 
                                                                        DeleteForAll ? 1 : 0);
        }
    }
}
