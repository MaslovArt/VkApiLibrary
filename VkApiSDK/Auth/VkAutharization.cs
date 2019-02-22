using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using VkApiSDK.Errors;
using VkApiSDK.Utils;
using System.IO;

namespace VkApiSDK
{
    public class VkAutharization
    {
        private const string   AUTH_URL = "https://oauth.vk.com/authorize?client_id={0}&display=page&redirect_uri=https://oauth.vk.com/blank.html&display=page&scope={1}&response_type=token&v=5.92",
                               AUTH_DATA_FILE = "authData.dat";

        private string         _appID,
                               _scope;
        private AuthData       _authData;
        Func<string, string, string, AuthData> _authMethod;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AppID">ID вк приложения</param>
        /// <param name="Scope">Список разрещений.</param>
        public VkAutharization(string AppID, string Scope, Func<string, string, string, AuthData> AuthMethod)
        {
            _authMethod = AuthMethod;
            _appID = AppID;
            _scope = Scope;
        }

        public AuthData AuthData
        {
            get { return _authData; }
            private set { _authData = value; }
        }

        /// <summary>
        /// Проверяет сохраненный токен.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IfAccessTokenExist()
        {
            return await DataSerializer.LoadInfo(out _authData, AUTH_DATA_FILE);
        }

        /// <summary>
        /// Удаляет токен.
        /// </summary>
        public void DeleteAccessToken()
        {
            if (File.Exists(AUTH_DATA_FILE))
                File.Delete(AUTH_DATA_FILE);
        }

        /// <summary>
        /// Выполняет авторизацию
        /// </summary>
        /// <param name="OnAuthError"></param>
        /// <returns></returns>
        public async Task<AuthData> AuthAsync()
        {
            if (!IfAccessTokenExist().Result)
            {
                AuthData = _authMethod(AUTH_URL, _appID, _scope);
                await DataSerializer.SaveInfo(AuthData, AUTH_DATA_FILE);

                Debug.WriteLine("Request to get token");
            }

            Debug.WriteLine("We have token");

            return AuthData;
        }
    }
}
