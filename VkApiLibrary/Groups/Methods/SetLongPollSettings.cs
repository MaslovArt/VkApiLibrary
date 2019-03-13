using static System.Convert;

namespace VkApiSDK.Groups.Methods
{
    /// <summary>
    /// Задаёт настройки для Bots Long Poll API в сообществе
    /// </summary>
    class SetLongPollSettings : GetLongPollSettings
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>SetLongPollSettings</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="GroupID">ID группы</param>
        public SetLongPollSettings(string AccessToken, int GroupID)
            :base(AccessToken, GroupID)
        {
            VkApiMethodName = "groups.setLongPollSettings";
            ApiVersion = "5.92";
        }

        /// <summary>
        /// Включить Bots Long Poll
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Версия API
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Уведомления о новых сообщениях
        /// </summary>
        public bool NewMessage { get; set; }

        /// <summary>
        /// Уведомления об исходящем сообщении
        /// </summary>
        public bool ReplyMessage { get; set; }

        /// <summary>
        /// Уведомления о подписке на сообщения
        /// </summary>
        public bool AllowMessage { get; set; }

        /// <summary>
        /// Уведомления о запрете на сообщения
        /// </summary>
        public bool DenyMessage { get; set; }

        /// <summary>
        /// Уведомления о редактировании сообщения
        /// </summary>
        public bool EditMessage { get; set; }

        /// <summary>
        /// Уведомления о вступлении в сообщество 
        /// </summary>
        public bool GroupJoin { get; set; }

        /// <summary>
        /// Уведомления о выходе из сообщества
        /// </summary>
        public bool GroupLeave { get; set; }

        protected override string GetMethodApiParams()
        {
            return base.GetMethodApiParams() +
                string.Format("&enabled={0}&api_version={1}&message_new={2}&message_reply={3}&message_allow={4}" + 
                "&message_deny={5}&message_edit={6}&group_join={7}&group_leave={8}", ToInt32(Enable),
                                                                                     ApiVersion,
                                                                                     ToInt32(NewMessage),
                                                                                     ToInt32(ReplyMessage),
                                                                                     ToInt32(AllowMessage),
                                                                                     ToInt32(DenyMessage),
                                                                                     ToInt32(DenyMessage),
                                                                                     ToInt32(GroupJoin),
                                                                                     ToInt32(GroupLeave));
        }
    }
}
