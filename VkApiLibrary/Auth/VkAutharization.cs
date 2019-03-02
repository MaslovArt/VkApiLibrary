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
using VkApiSDK.Interfaces;
using System.IO;

namespace VkApiSDK
{
    public class VkAutharization
    {
        private const string AUTH_URL = "https://oauth.vk.com/authorize?client_id={0}&display=page&redirect_uri=https://oauth.vk.com/blank.html&display=page&scope={1}&response_type=token&v=5.92";

        private string         _appID,
                               _scope,
                               _dataName = "authdata";
        private AuthData       _authData;
        private Func<string, string, string, AuthData> _authMethod;
        private IDataProvider DataProvider;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="AppID">ID вк приложения</param>
        /// <param name="Scope">Список разрещений.</param>
        public VkAutharization(string AppID, string Scope, IDataProvider DataProvider, Func<string, string, string, AuthData> AuthMethod)
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
        /// Выполняет авторизацию
        /// </summary>
        /// <param name="OnAuthError"></param>
        /// <returns></returns>
        public AuthData Auth()
        {
            if (DataProvider != null)
            {
                object obj;
                if(DataProvider.LoadObject(out obj, _dataName))
                    AuthData = obj as AuthData;
            }

            if (AuthData == null)
            {
                AuthData = _authMethod(AUTH_URL, _appID, _scope);
                if (DataProvider != null)
                    DataProvider.SaveObject(AuthData, _dataName);
            }

            return AuthData;
        }
    }
}
