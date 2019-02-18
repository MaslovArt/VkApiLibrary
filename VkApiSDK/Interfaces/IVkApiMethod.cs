using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiSDK
{
    public interface IVkApiMethod
    {
        /// <summary>
        /// Возвращает строку для api запроса.
        /// </summary>
        /// <returns>Uri</returns>
        string GetRequestString();
    }
}
