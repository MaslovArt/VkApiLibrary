﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using VkApiSDK.Messages.Methods;
using VkApiSDK.Models.Messages;
using VkApiSDK.Models;
using VkApiSDK.Models.Attachments;
using VkApiSDK.Models.Response;
using VkApiSDK.Auth;

namespace VkApiSDK.Messages
{
    /// <summary>
    /// Методы для работы с личными сообщениями. 
    /// </summary>
    public class MessageMethods : VkApiMethodGroup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>MessageMethods</c>
        /// </summary>
        /// <param name="AuthData">Токен доступа</param>
        /// <param name="VkRequest">Класс для отправки запросов</param>
        public MessageMethods(AuthData AuthData, IVkRequest VkRequest = null)
            : base(AuthData, VkRequest)
        { }

        /// <summary>
        /// Получает список диалогов
        /// </summary>
        /// <param name="count">Кол-во диалогов в запросе</param>
        /// <param name="offset">Смещение для получения данных</param>
        /// <returns></returns>
        public async Task<VkResponse<DialogsData>> GetDialogsAsync(int count = 20, int offset = 0)
        {
            return await _vkRequest.Dispath<VkResponse<DialogsData>>(
                new GetConversations(
                    AccessToken: AuthData.AccessToken,
                    Offset: offset,
                    Count: count
                ));
        }

        /// <summary>
        /// Отправляет сообщение.
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="message">Текст</param>
        /// <returns></returns>
        public async Task<VkResponse<int>> SendMessage(Peer peer, string message, IEnumerable<VkMessage> FwdMessages = null, 
            IEnumerable<BaseAttachment> Attachments = null, VkMessage ReplyTo = null)
        {
            var attachment = "";
            if (Attachments != null)
                attachment = string.Join(",", Attachments.Select(a => a.ToString()));

            return await _vkRequest.Dispath<VkResponse<int>>(
                new SendMessage(
                    AccessToken: AuthData.AccessToken,
                    PeerID: ConvertIDIfChat(peer),
                    Message: message,
                    ForwardMessageIDs: FwdMessages?.Select(fwd => fwd.ID),
                    ReplyTo: ReplyTo?.ID,
                    Attachments: attachment
                ));
        }

        /// <summary>
        /// Удаляет сообщение
        /// </summary>
        /// <param name="Messages">Сообщения</param>
        /// <param name="DeleteForAll">Удалять для всех</param>
        /// <returns></returns>
        public async Task<VkResponse<Dictionary<string, int>>> DeleteMessage(IEnumerable<VkMessage> Messages, bool DeleteForAll = true)
        {
            return await _vkRequest.Dispath<VkResponse<Dictionary<string, int>>>(
                new DeleteMessage(
                    AccessToken: AuthData.AccessToken,
                    MessageIDs: Messages.Select(m => m.ID),
                    DeleteForAll: DeleteForAll
                ));
        }

        /// <summary>
        /// Редактирует сообщение
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="editMessage">Сообщение для редактирования</param>
        /// <param name="newText">Текст сообщения</param>
        /// <param name="attachments">Приложения</param>
        /// <returns></returns>
        public async Task<VkResponse<int>> EditMessage(Peer peer, VkMessage editMessage, string newText, string attachments = "")
        {
            return await _vkRequest.Dispath<VkResponse<int>>(
                new EditMessage(
                    AccessToken: AuthData.AccessToken,
                    PeerID: peer.ID,
                    MessageID: editMessage.ID,
                    Message: newText,
                    Attachments: attachments
                ));
        }

        /// <summary>
        /// Закрепляет сообщение
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="pinMessage">Сообщение для закрепления</param>
        /// <returns></returns>
        public async Task<VkResponse<object>> PinMessage(Peer peer, VkMessage pinMessage)
        {
            return await _vkRequest.Dispath<VkResponse<object>>(
                new PinMessage(
                    AccessToken: AuthData.AccessToken,
                    PeerID: ConvertIDIfChat(peer),
                    MessageID: pinMessage.ID
                ));
        }

        /// <summary>
        /// Открепляет сообщение
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <returns></returns>
        public async Task<VkResponse<int>> UnpinMessage(Peer peer)
        {
            return await _vkRequest.Dispath<VkResponse<int>>(
                new UnpinMesaage(
                    AccessToken: AuthData.AccessToken,
                    PeerID: ConvertIDIfChat(peer)
                ));
        }

        /// <summary>
        /// Помечает сообщения как прочитанные
        /// </summary>
        /// <param name="fromMessage">Сообщение, начиная с которого пометить как прочитанные</param>
        /// <returns></returns>
        public async Task<VkResponse<int>> MarkAsRead(VkMessage fromMessage)
        {
            return await _vkRequest.Dispath<VkResponse<int>>(
                new MarkAsRead(
                    AccessToken: AuthData.AccessToken,
                    PeerID: fromMessage.PeerID,
                    StartMessageID: fromMessage.ID
                ));
        }

        /// <summary>
        /// Устанавливает активность набора сообщения
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="activityType">Тип набора сообщения</param>
        /// <returns></returns>
        public async Task<VkResponse<int>> SetActivity(Peer peer, string activityType)
        {
            return await _vkRequest.Dispath<VkResponse<int>>(
                new SetActivity(
                    AccessToken: AuthData.AccessToken,
                    PeerID: peer.ID,
                    Type: activityType
                ));
        }

        /// <summary>
        /// Получает историю переписки
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <param name="count">Кол-во сообщений</param>
        /// <param name="offset">Смещение</param>
        /// <param name="startMessageID">Начиная с какого получать</param>
        /// <param name="fields">Дополнительные поля</param>
        /// <returns></returns>
        public async Task<VkResponse<ArrayResponse<VkMessage>>> GetDialogHistory(Peer peer, int count = 20, int offset = 0, int startMessageID = -1, IEnumerable<string> fields = null)
        {
            return await _vkRequest.Dispath<VkResponse<ArrayResponse<VkMessage>>>(
                new GetDialogHistory(
                    AccessToken: AuthData.AccessToken,
                    PeerID: ConvertIDIfChat(peer),
                    Offset: offset,
                    Count: count,
                    StartMessageID: startMessageID,
                    Fields: fields
                ));
        }

        /// <summary>
        /// Получает приложения диалога
        /// </summary>
        /// <param name="mediaType">Тип</param>
        /// <param name="startFrom">Смещение</param>
        /// <param name="count">Кол-во</param>
        /// <param name="photoSizes">Возвращать фото в спиц формате</param>
        /// <param name="fields">Дополнительные поля</param>
        /// <returns></returns>
        public async Task<VkResponse<AttachmentData>> GetDialogAttachment(Peer peer, string mediaType, string startFrom, int count = 10, bool photoSizes = false, IEnumerable<string> fields = null)
        {
            return await _vkRequest.Dispath<VkResponse<AttachmentData>>(
                new GetHistoryAttachments(
                    AccessToken: AuthData.AccessToken,
                    PeerID: peer.ID,
                    MediaType: mediaType,
                    StartFrom: startFrom,
                    Count: count,
                    PhotoSizes: photoSizes,
                    Fields: fields
                ));
        }

        /// <summary>
        /// Удаляет диалог
        /// </summary>
        /// <param name="peer">Идентификатор назначения</param>
        /// <returns></returns>
        public async Task<bool> DeleteDialog(Peer peer)
        {
            var result = await GetDialogHistory(peer, 1);
            if (result == null)
                return false;

            var deleteCallNumber = Math.Ceiling(result.Response.Count / 10000d);
            //var deleteResponse = 0;

            for (int i = 0; i < deleteCallNumber; i++)
            {
                var delRes = await _vkRequest.Dispath<VkResponse<object>>(
                    new DeleteConversation(
                        AccessToken: AuthData.AccessToken,
                        PeerID: ConvertIDIfChat(peer)
                    ));
                if (delRes == null)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Помечает сообщения как важные либо снимает отметку.
        /// </summary>
        /// <param name="Messages">Сообщения</param>
        /// <param name="Important">Отметить важными</param>
        /// <returns></returns>
        public async Task<VkResponse<int[]>> MarkAsImportant(IEnumerable<VkMessage> Messages, bool Important = true)
        {
            return await _vkRequest.Dispath<VkResponse<int[]>>(
                new MarkAsImportant(
                    AccessToken: AuthData.AccessToken,
                    MessageIDs: Messages.Select(m => m.ID),
                    Important: Important
                ));
        }

        #region Private methods

        private int ConvertIDIfChat(Peer peer)
        {
            if (peer.Type == "chat")
                return 2000000000 + peer.ID;
            return peer.ID;
        }

        #endregion
    }
}
