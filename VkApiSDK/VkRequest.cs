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

        public event Action<Error> OnRequestError;

        /// <summary>
        /// Осуществляет запрос к api
        /// </summary>
        /// <typeparam name="T">Тип ответа</typeparam>
        /// <param name="vkApiMethod">Api метод</param>
        /// <returns>Объект json ответа</returns>
        public async Task<T> Dispath<T>(IVkApiMethod vkApiMethod) where T : IVkResponse
        {
            string reqUri = vkApiMethod.GetRequestString();
            var responseStringJSON = await client.GetStringAsync(reqUri);

            Debug.WriteLine("REqURL " + reqUri);

            T result = default(T);

            result = JsonConvert.DeserializeObject<T>(responseStringJSON);

            if(result.ChechIfResponseNull())
            {
                var err = JsonConvert.DeserializeObject<ErrorResponse>(responseStringJSON);
                OnRequestError(err.Error);
            }

            return result;
        }
    }
}
