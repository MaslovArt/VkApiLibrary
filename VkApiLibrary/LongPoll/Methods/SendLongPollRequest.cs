using VkApiSDK.Abstraction;

namespace VkApiSDK.LongPoll.Methods
{
    /// <summary>
    /// LongPoll запрос
    /// </summary>
    public class SendLongPollRequest : IVkApiMethod
    {
        private string _URL = "https://{0}?act=a_check&key={1}&ts={2}&wait={3}&mode={4}&version={5}";

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>SendLongPollRequest</c>
        /// </summary>
        /// <param name="Server">Адрес сервера</param>
        /// <param name="Key">Cекретный ключ сессии</param>
        /// <param name="Ts">Номер последнего события, начиная с которого нужно получать данные</param>
        /// <param name="Mode">Дополнительные опции ответа</param>
        /// <param name="WaitTime">Время ожидания</param>
        public SendLongPollRequest(string Server, string Key, int Ts, int Mode, int WaitTime = 25)
        {
            this.Server = Server;
            this.Key = Key;
            this.Version = "2";
            this.WaitTime = WaitTime;
            this.Ts = Ts;
            this.Mode = Mode;
        }

        /// <summary>
        /// Адрес сервера
        /// </summary>
        public string Server { get; private set; }

        /// <summary>
        /// Cекретный ключ сессии
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Версия
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Время ожидания
        /// <para>
        /// Так как некоторые прокси-серверы обрывают соединение после 30 секунд, рекомендуется указывать wait=25
        /// </para>
        /// </summary>
        public int WaitTime { get; private set; }

        /// <summary>
        /// Номер последнего события, начиная с которого нужно получать данные
        /// </summary>
        public int Ts { get; set; }

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

        public string GetRequestString()
        {
            return string.Format(_URL, Server, Key, Ts, WaitTime, Mode, Version);
        }
    }
}
