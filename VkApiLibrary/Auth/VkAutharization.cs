using System;
using VkApiSDK.Abstraction;

namespace VkApiSDK
{
    public class VkAutharization
    {
        private const string AUTH_URL = "https://oauth.vk.com/authorize?client_id={0}&display=page&redirect_uri=https://oauth.vk.com/blank.html&display=page&scope={1}&response_type=token&v=5.92";
        private const string AUTH_DATA_PATH = "authdata";
        private IDataProvider DataProvider;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AppID">ID вк приложения</param>
        /// <param name="Scope">Список разрещений.</param>
        /// <param name="DataProvider">Способ сохранения информации.</param>
        public VkAutharization(string AppID, string Scope, IDataProvider DataProvider = null)
        {
            this.AppID = AppID;
            this.Scope = Scope;
            this.DataProvider = DataProvider;
        }

        /// <summary>
        /// Данные для доступа к апи
        /// </summary>
        public AuthData AuthData { get; private set; }

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
        /// <returns>Токен</returns>
        public AuthData Auth(Func<string, AuthData> AuthMethod)
        {
            AuthData = AuthMethod(string.Format(AUTH_URL, AppID, Scope));

            if (DataProvider != null && AuthData != null)
                DataProvider.SaveObject(AuthData, AUTH_DATA_PATH);

            return AuthData;
        }

        /// <summary>
        /// Пытается получить токен доступа из памяти
        /// </summary>
        /// <returns>Токен</returns>
        public AuthData TryGetAuthFromMemory()
        {
            if (DataProvider == null) return null;

            AuthData ad;
            bool isLoad = DataProvider.LoadObject(out ad, AUTH_DATA_PATH);

            if(isLoad)
            {
                AuthData = ad;
                return AuthData;
            }

            return null;
        }
    }
}
