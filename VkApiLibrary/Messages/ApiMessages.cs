using System.Collections.Generic;
using VkApiSDK.Messages.Attachments;
using VkApiSDK.Messages.Dialogs;

namespace VkApiSDK.Messages
{
    public static class ApiMessages
    {
        public static GetConversations GetConversations(string AccessToken, int Offset = 0, int Count = 10, IEnumerable<string> Fields = null, string Filter = DialogFilter.All)
        {
            return new GetConversations(AccessToken, Fields, Offset, Count, Filter);
        }

        public static SendMessage SendMessage(string AccessToken, int PeedID, string Message, string Attachments = "")
        {
            return new SendMessage(AccessToken, PeedID, Message, Attachments);
        }

        public static SetActivity SetActivity(string AccessToken, int UserID, string ActivityType)
        {
            return new SetActivity(AccessToken, UserID, ActivityType);
        }

        public static GetDialogHistory GetDialogHistory(string AccessToken, int PeerID, int Offset = 0, int Count = 20, int StartMessageID = -1, IEnumerable<string> Fields = null)
        {
            return new GetDialogHistory(AccessToken, PeerID, Offset, Count, StartMessageID, Fields);
        }

        public static GetHistoryAttachments GetHistoryAttachments(string AccessToken, int PeerID, string MediaType, string StartFrom, int Count = 30, bool PhotoSizes = false, IEnumerable<string> Fields = null)
        {
            return new GetHistoryAttachments(AccessToken, PeerID, MediaType, StartFrom, Count, PhotoSizes, Fields);
        }

        public static DeleteMessage DeleteMessage(string AccessToken, IEnumerable<int> MessageIDs, bool DeleteForAll = true)
        {
            return new DeleteMessage(AccessToken, MessageIDs, DeleteForAll);
        }

        public static EditMessage EditMessage(string AccessToken, int PeedID, int MessageID, string Message, string Attachments = "")
        {
            return new EditMessage(AccessToken, PeedID, MessageID, Message, Attachments);
        }

        public static GetChat GetChat(string AccessToken, int ChatID, IEnumerable<string> Fields)
        {
            return new GetChat(AccessToken, ChatID, Fields);
        }

        public static EditChat EditChat(string AccessToken, int ChatID, string Title)
        {
            return new EditChat(AccessToken, ChatID, Title);
        }

        public static PinMessage Pin(string AccessToken, int PeerID, int MessageID)
        {
            return new PinMessage(AccessToken, PeerID, MessageID);
        }

        public static UnpinMesaage Unpin(string AccessToken, int PeerID)
        {
            return new UnpinMesaage(AccessToken, PeerID);
        }

        public static MarkAsRead MarkAsRead(string AccessToken, int PeerID, int StartMessageID)
        {
            return new MarkAsRead(AccessToken, PeerID, StartMessageID);
        }

        public static AddChatUser AddChatUser(string AccessToken, int ChatID, int UserID)
        {
            return new AddChatUser(AccessToken, ChatID, UserID);
        }

        public static CreateChat CreateChat(string AccessToken, string Title, IEnumerable<int> UserIDs)
        {
            return new CreateChat(AccessToken, Title, UserIDs);
        }

        public static DeleteConversation DeleteConversation(string AccessToken, int PeerID, int Offset = 0, int Count = 10000)
        {
            return new DeleteConversation(AccessToken, PeerID, Offset, Count);
        }

        public static RemoveChatUser RemoveChatUser(string AccessToken, int ChatID, int UserID)
        {
            return new RemoveChatUser(AccessToken, ChatID, UserID);
        }
    }
}
