using System;
using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using Newtonsoft.Json;

namespace VkApiSDK.Auth
{
    public class VkAutharization
    {
        private const string authUrl = "https://oauth.vk.com/authorize";
        private const string redirectUrl = "https://oauth.vk.com/blank.html";
        private IDataProvider<string> dataProvider;
        private string authDataPath = "authData.dat";

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AppID">ID вк приложения</param>
        /// <param name="Scope">Список разрещений.</param>
        public VkAutharization(string AppID, string Scope, IDataProvider<string> dataProvider)
        {
            this.AppID = AppID;
            this.Scope = Scope;
            this.dataProvider = dataProvider;
        }

        /// <summary>
        /// Данные для доступа к апи
        /// </summary>
        public AuthData AuthData { get; set; }

        /// <summary>
        /// ID приложения Вк
        /// </summary>
        public string AppID { get; private set; }

        /// <summary>
        /// Список разрешений
        /// </summary>
        public string Scope { get; private set; }

        /// <summary>
        /// Выполняет авторизацию
        /// </summary>
        /// <param name="AuthMethod">Метод, который осуществляет переход по ссылке для подтверждения доступа к аккаунту</param>
        public void Auth(Func<string, string, string, string, AuthData> AuthMethod)
        {
             AuthData = AuthMethod(AppID, Scope, authUrl, redirectUrl);
        }

        public bool SaveToken()
        {
            if (AuthData == null)
                return false;

            var authDataJson = JsonConvert.SerializeObject(AuthData);
            return dataProvider.SaveObject(authDataJson, authDataPath);
        }

        public  AuthData TryGetToken()
        {
            string authDataJson;

            if(dataProvider.LoadObject(out authDataJson, authDataPath))
            {
                var authData = JsonConvert.DeserializeObject<AuthData>(authDataJson);
                return authData;
            }

            return null;
        }

        public bool DeleteToken()
        {
            return dataProvider.DeleteObject(authDataPath);
        }
    }
}
