using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Abstraction;

namespace VkApiSDK.Account.Methods
{
    /// <summary>
    /// Возвращает ненулевые значения счетчиков пользователя.
    /// </summary>
    public class GetCounters : VkApiMethod
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>GetCounters</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        /// <param name="Filters">Счетчики, информацию о которых нужно вернуть</param>
        public GetCounters(string AccessToken, IEnumerable<string> Filters)
            :base(AccessToken)
        {
            VkApiMethodName = "account.getCounters";
            this.Filters = Filters;
        }

        /// <summary>
        /// Счетчики, информацию о которых нужно вернуть
        /// </summary>
        public IEnumerable<string> Filters { get; set; }

        protected override string GetMethodApiParams()
        {
            return string.Format("&filter={0}", ArrayToString(Filters));
        }
    }
}
