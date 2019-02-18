using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK.Messages
{
    public class DialogRenderData
    {
        /// <summary>
        /// Тип диалого
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Название диалога или имя пользователя
        /// </summary>
        public string PeerName { get; set; }

        /// <summary>
        /// Время последнего сообщения
        /// </summary>
        public string DialogTime { get; set; }

        /// <summary>
        /// Тело последнего сообщения
        /// </summary>
        public string LastMessage { get; set; }
        
        /// <summary>
        /// Кол-во непрочитанных сообщенний
        /// </summary>
        public int UnreadMsgCount { get; set; }
    }
}
