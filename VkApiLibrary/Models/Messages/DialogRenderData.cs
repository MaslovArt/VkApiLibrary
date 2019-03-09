namespace VkApiSDK.Model.Messages
{
    public class DialogRenderData
    {
        /// <summary>
        /// Тип диалого
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

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

        /// <summary>
        /// Исходящее сообщение
        /// </summary>
        public bool Out { get; set; }
    }
}
