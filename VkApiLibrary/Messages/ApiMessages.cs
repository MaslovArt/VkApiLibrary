using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkApiSDK.Messages.Dialogs;
using VkApiSDK.Users;

namespace VkApiSDK.Messages
{
    public static class ApiMessages
    {
        public static GetConversations GetConversations(string AccessToken, int Offset = 0, int Count = 10, IEnumerable<string> Fields = null, string Filter = DialogFilter.All)
        {
            return new GetConversations(AccessToken, Fields, Offset, Count, Filter);
        }

        public static GetDialogHistory GetHistory(string AccessToken, string UserID, int Offser = 0, int Count = 20, int StartMessageID = -1, IEnumerable<string> Fields = null)
        {
            return new GetDialogHistory(AccessToken, UserID, Offser, Count, StartMessageID, Fields);
        }

        public static SendMessage SendMessage(string AccessToken, string PeedID, string Message, string Attachments = "")
        {
            return new SendMessage(AccessToken, PeedID, Message, Attachments);
        }

        public static SetActivity SetActivity(string AccessToken, string UserID, string ActivityType)
        {
            return new SetActivity(AccessToken, UserID, ActivityType);
        }

        public static GetDialogHistory GetDialogHistory(string AccessToken, string UserID, int Offset = 0, int Count = 20, int StartMessageID = -1, IEnumerable<string> Fields = null)
        {
            return new GetDialogHistory(AccessToken, UserID, Offset, Count, StartMessageID, Fields);
        }

        public static DeleteMessage DeleteMessage(string AccessToken, IEnumerable<string> MessageIDs, bool DeleteForAll = true)
        {
            return new DeleteMessage(AccessToken, MessageIDs, DeleteForAll);
        }

    }
}
