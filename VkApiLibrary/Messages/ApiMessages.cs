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

        public static SendMessage SendMessage(string AccessToken, string PeedID, string Message, string Attachments = "")
        {
            return new SendMessage(AccessToken, PeedID, Message, Attachments);
        }

        public static SetActivity SetActivity(string AccessToken, string UserID, string ActivityType)
        {
            return new SetActivity(AccessToken, UserID, ActivityType);
        }

        public static GetDialogHistory GetDialogHistory(string AccessToken, string PeerID, int Offset = 0, int Count = 20, int StartMessageID = -1, IEnumerable<string> Fields = null)
        {
            return new GetDialogHistory(AccessToken, PeerID, Offset, Count, StartMessageID, Fields);
        }

        public static GetHistoryAttachments GetHistoryAttachments(string AccessToken, string PeerID, string MediaType, string StartFrom, int Count = 30, bool PhotoSizes = false, IEnumerable<string> Fields = null)
        {
            return new GetHistoryAttachments(AccessToken, PeerID, MediaType, StartFrom, Count, PhotoSizes, Fields);
        }

        public static DeleteMessage DeleteMessage(string AccessToken, IEnumerable<string> MessageIDs, bool DeleteForAll = true)
        {
            return new DeleteMessage(AccessToken, MessageIDs, DeleteForAll);
        }

        public static EditMessage EditMessage(string AccessToken, string PeedID, string MessageID, string Message, string Attachments = "")
        {
            return new EditMessage(AccessToken, PeedID, MessageID, Message, Attachments);
        }

        public static GetChat GetChat(string AccessToken, string ChatID, IEnumerable<string> Fields)
        {
            return new GetChat(AccessToken, ChatID, Fields);
        }

        public static EditChat EditChat(string AccessToken, string ChatID, string Title)
        {
            return new EditChat(AccessToken, ChatID, Title);
        }

        public static PinMessage Pin(string AccessToken, string PeerID, string MessageID)
        {
            return new PinMessage(AccessToken, PeerID, MessageID);
        }

        public static UnpinMesaage Unpin(string AccessToken, string PeerID)
        {
            return new UnpinMesaage(AccessToken, PeerID);
        }

        public static MarkAsRead MarkAsRead(string AccessToken, string PeerID, string StartMessageID)
        {
            return new MarkAsRead(AccessToken, PeerID, StartMessageID);
        }

        public static AddChatUser AddChatUser(string AccessToken, string ChatID, string UserID)
        {
            return new AddChatUser(AccessToken, ChatID, UserID);
        }

        public static CreateChat CreateChat(string AccessToken, string Title, IEnumerable<string> UserIDs)
        {
            return new CreateChat(AccessToken, Title, UserIDs);
        }

        public static DeleteConversation DeleteConversation(string AccessToken, string PeerID, int Offset = 0, int Count = 10000)
        {
            return new DeleteConversation(AccessToken, PeerID, Offset, Count);
        }

        public static RemoveChatUser RemoveChatUser(string AccessToken, string ChatID, string UserID, string MemberID = "")
        {
            return new RemoveChatUser(AccessToken, ChatID, UserID, MemberID);
        }
    }
}
