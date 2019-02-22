using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VkApiSDK.Auth.WinFormAuth
{
    public partial class VkAuthForm : Form
    {
        private string _appID,
                       _scope,
                       _uri;

        public VkAuthForm(string Uri, string AppID, string Scope)
        {
            InitializeComponent();
            _uri = Uri;
            _appID = AppID;
            _scope = Scope;
        }

        public AuthData AuthData { get; private set; }

        private void getToken_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Debug.WriteLine(webBrowser.Url.ToString());
            if (webBrowser.Url.ToString().IndexOf("#access_token=") != -1)
            {
                GetUserToken();
                Close();
            }
        }

        private void VkAuthForm_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(String.Format(_uri, _appID, _scope));
            webBrowser.Navigate(String.Format(_uri, _appID, _scope));
        }

        private void GetUserToken()
        {
            char Symbol = '=';
            string[] URL = webBrowser.Url.ToString().Split(Symbol);
            AuthData = new AuthData()
            {
                AccessToken = URL[1],
                Expires = URL[2],
                UserID = URL[3]
            };
        }
    }
}
