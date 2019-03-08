using VkApiSDK.Requests;

namespace VkApiSDK.LongPoll
{
    /// <summary>
    /// Возвращает данные, необходимые для подключения к Long Poll серверу.
    /// </summary>
    /// <remarks>
    /// Требуются права доступа: messages.
    /// </remarks>
    public class GetLongPollServer : VkApiMethod
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="NeedPts">Возвращать поле pts</param>
        /// <param name="LpVersion">Версия для подключения к Long Poll</param>
        public GetLongPollServer(string AccessToken, bool NeedPts = true)
            :base(AccessToken)
        {
            VkApiMethodName = "messages.getLongPollServer";
            this.NeedPts = NeedPts;
        }

        /// <summary>
        /// Возвращать поле pts
        /// </summary>
        public bool NeedPts { get; set; }

        /// <summary>
        /// Версия для подключения к Long Poll
        /// </summary>
        public string LpVersion { get; private set; } = "2";

        protected override string GetMethodApiParams()
        {
            return string.Format("&need_pts={0}&lp_version={1}", NeedPts, LpVersion);
        }
    }
}
