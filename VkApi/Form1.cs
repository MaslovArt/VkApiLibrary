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
using VkApiSDK;
using VkApiSDK.Users;
using VkApiSDK.Utils;
using VkApiSDK.Auth.WinFormAuth;
using VkApiSDK.Messages.History;

namespace VkApiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //70316714

            var dt = DateTime.Now;
            richTextBox1.Text = dt.ToString();
        }

        VkClient vkClient;
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private async void buttonAuth_Click(object sender, EventArgs e)
        {
            vkClient = new VkClient();
            vkClient.OnRequestError += (o) => { richTextBox1.Text = o.Message; };

            await vkClient.AuthAsync((path, id, scope) => 
            {
                using (VkAuthForm vaf = new VkAuthForm(path, id, scope))
                {
                    vaf.ShowDialog();
                    richTextBox1.Text = vaf.AuthData.ToString();
                    return vaf.AuthData;
                }
            });    
        }
    }
}
