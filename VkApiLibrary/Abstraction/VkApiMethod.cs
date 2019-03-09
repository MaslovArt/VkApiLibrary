using System.Collections.Generic;

namespace VkApiSDK.Abstraction
{
    /// <summary>
    /// Базовый класс методов вк api.
    /// </summary>
    public abstract class VkApiMethod : IVkApiMethod
    {
        private string _apiUri = "https://api.vk.com/method/",
                       _apiVersion = "5.92";

        public VkApiMethod(string AccessToken, IEnumerable<string> Fields = null)
        {
            this.AccessToken = AccessToken;
            this.Fields = Fields ?? new string[] { };
        }

        /// <summary>
        /// Имя api метода.
        /// </summary>
        public string VkApiMethodName { get; protected set; }

        /// <summary>
        /// Токен для доступа к api.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Cписок дополнительных полей, которые необходимо вернуть.
        /// </summary>
        public IEnumerable<string> Fields { get; set; }

        /// <summary>
        /// Возвращает набор параметров для запроса.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetMethodApiParams();

        /// <summary>
        /// Возвращает uri запроса.
        /// </summary>
        /// <returns>Uri</returns>
        public string GetRequestString()
        {
            //var @params = from p in this.GetType().GetProperties()
            //              let attr = p.GetCustomAttributes(typeof(RequestParamAttr), true)
            //              where attr.Length == 1
            //              select new
            //              {
            //                  PropValue = p.GetValue(this),
            //                  AttrName = (attr.First() as RequestParamAttr).ParamName
            //              };

            //var _reqUriParams = "";
            //foreach (var param in @params)
            //    _reqUriParams += string.Format("&{0}={1}", param.AttrName, param.PropValue);

            //return string.Format("{0}{1}?access_token={2}&fields={3}{4}&v={5}", _apiUri, 
            //                                                                    VkApiMethodName,
            //                                                                    AccessToken,
            //                                                                    ArrayToString(Fields),
            //                                                                    _reqUriParams,
            //                                                                    _apiVersion);

            return string.Format("{0}{1}?access_token={2}&fields={3}{4}&v={5}", _apiUri,
                                                                                VkApiMethodName,
                                                                                AccessToken,
                                                                                ArrayToString(Fields),
                                                                                GetMethodApiParams(),
                                                                                _apiVersion);
        }

        /// <summary>
        /// Возвращает строку всех элементов через запятую без пробелов.
        /// </summary>
        /// <param name="items">Массив данных</param>
        /// <returns>Строка</returns>
        protected string ArrayToString<T>(IEnumerable<T> items)
        {
            return string.Join(",", items);
        }
    }
}
