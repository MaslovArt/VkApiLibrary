using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using VkApiSDK.Errors;

namespace VkApiSDK
{
    class VkRequest
    {
        HttpClient client;

        public VkRequest()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Осуществляет запрос к api
        /// </summary>
        /// <typeparam name="T">Тип ответа</typeparam>
        /// <param name="vkApiMethod">Api метод</param>
        /// <returns>Объект json ответа</returns>
        public async Task<T> Dispath<T>(IVkApiMethod vkApiMethod, Action<Error> OnRequestError = null) where T : class, IVkResponse
        {
            string reqUri = vkApiMethod.GetRequestString();
            var responseStringJSON = await client.GetStringAsync(reqUri);

            Debug.WriteLine("REqURL " + reqUri);

            T result = null;

            result = JsonConvert.DeserializeObject<T>(responseStringJSON);

            if(result.ChechIfResponseNull())
            {
                if (OnRequestError != null)
                {
                    var err = JsonConvert.DeserializeObject<ErrorResponse>(responseStringJSON);
                    OnRequestError(err.Error);
                }
            }

            return result;
        }
    }
}
