using VkApiSDK.Abstraction;

namespace VkApiSDK.Groups.Methods
{
    public class SendGroupLongPollRequest : IVkApiMethod
    {
        private string _URL = "https://{0}?act=a_check&key={1}&ts={2}&wait={3}";

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>SendLongPollRequest</c>
        /// </summary>
        /// <param name="Server">Адрес сервера</param>
        /// <param name="Key">Cекретный ключ сессии</param>
        /// <param name="Ts">Номер последнего события, начиная с которого нужно получать данные</param>
        /// <param name="WaitTime">Время ожидания</param>
        public SendGroupLongPollRequest(string Server, string Key, int Ts, int WaitTime = 25)
        {
            this.Server = Server;
            this.Key = Key;
            this.WaitTime = WaitTime;
            this.Ts = Ts;
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

        public string GetRequestString()
        {
            return string.Format(_URL, Server, Key, Ts, WaitTime);
        }
    }
}
