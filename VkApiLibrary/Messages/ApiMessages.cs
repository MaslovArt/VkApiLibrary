using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Messages.Dialogs;

namespace VkApiSDK.Messages
{
    public static class ApiMessages
    {
        public static GetConversations GetConversations(string AccessToken, string[] Fields = null, int Offset = 0, int Count = 10, string Filter = DialogFilter.All)
        {
            return new GetConversations(AccessToken, Fields, Offset, Count, Filter);
        }
    }
}
