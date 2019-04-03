using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using VkApiSDK.Abstraction;
using VkApiSDK.Models.Errors;
using VkApiSDK.Utils;

namespace VkApiSDK.Requests
{
    public class VkRequest : IVkRequest
    {
        private HttpClient client;

        public VkRequest()
        {
            client = new HttpClient();
            Timeout = 20;
        }

        public ILogger Logger { get; set; }

        public int Timeout
        {
            get { return (int)client.Timeout.TotalSeconds; }
            set { client.Timeout = new TimeSpan(0, 0, value); }
        }

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

            writeInfo(reqUri, LogLevel.Info);

            T result = default(T);
            if (responseStringJSON.StartsWith("{\"error\":{"))
            {
                writeInfo(responseStringJSON, LogLevel.Error);
                var err = JsonConvert.DeserializeObject<ErrorResponse>(responseStringJSON);
                result.SetError(err.Error);
            }
            else
            {
                writeInfo(responseStringJSON, LogLevel.Info);
                result = JsonConvert.DeserializeObject<T>(responseStringJSON);
            }
            return result;
        }

        private void writeInfo(string msg, LogLevel level)
        {
            if (Logger != null)
                Logger.WriteInfo(msg, (int)level);
        }

        private void writeEx(Exception ex, string msg)
        {
            if (Logger != null)
                Logger.WriteException(msg, ex);
        }
    }
}
