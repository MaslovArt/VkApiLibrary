using VkApiSDK.Abstraction;
using VkApiSDK.Groups.Methods;

namespace VkApiSDK.LongPoll.Methods
{
    /// <summary>
    /// LongPoll запрос
    /// </summary>
    public class SendLongPollRequest : SendGroupLongPollRequest
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>SendLongPollRequest</c>
        /// </summary>
        /// <param name="Server">Адрес сервера</param>
        /// <param name="Key">Cекретный ключ сессии</param>
        /// <param name="Ts">Номер последнего события, начиная с которого нужно получать данные</param>
        /// <param name="Mode">Дополнительные опции ответа</param>
        /// <param name="WaitTime">Время ожидания</param>
        public SendLongPollRequest(string Server, string Key, int Ts, int Mode, int WaitTime = 25)
            :base(Server, Key, Ts, WaitTime)
        {
            this.Version = "2";
            this.Mode = Mode;
        }

        /// <summary>
        /// Версия
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Дополнительные опции ответа
        /// <para>
        /// Сумма кодов опций из списка:
        /// <list type="modes">
        /// <item>2 — получать вложения;</item>
        /// <item>8 — возвращать расширенный набор событий;</item>
        /// <item>32 — возвращать <c>pts</c>;</item>
        /// <item>64 — в событии с кодом 8 (друг стал онлайн) возвращать дополнительные данные в поле <c>$extra</c>;</item>
        /// <item>128 — возвращать поле random_id;</item>
        /// </list>
        /// </para>
        /// </summary>
        public int Mode { get; private set; }

        public new string GetRequestString()
        {
            return base.GetRequestString() + string.Format("&mode={4}&version={5}", Mode, Version);
        }
    }
}
