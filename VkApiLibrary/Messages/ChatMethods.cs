using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkApiSDK.Abstraction;
using VkApiSDK.Messages.Methods;
using VkApiSDK.Models;
using VkApiSDK.Models.Response;

namespace VkApiSDK.Messages
{
    /// <summary>
    /// Методы для работы с чатами. 
    /// </summary>
    public class ChatMethods : VkApiMethodGroup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>ChatMethods</c>
        /// </summary>
        /// <param name="AuthData">Токен доступа</param>
        /// <param name="VkRequest">Класс для отправки запросов</param>
        public ChatMethods(AuthData AuthData, IVkRequest VkRequest = null)
            :base(AuthData, VkRequest)
        { }

        /// <summary>
        /// Получает информацию о чате
        /// </summary>
        /// <param name="chatID">ID чата</param>
        /// <param name="fields">Дополнительные поля</param>
        /// <returns></returns>
        public async Task<Chat> GetChat(int chatID, IEnumerable<string> fields = null)
        {
            var result = await _vkRequest.Dispath<VkResponse<Chat>>(
                new GetChat(
                    AccessToken: AuthData.AccessToken,
                    ChatID: chatID,
                    Fields: fields
                ));

            return result?.Response;
        }

        /// <summary>
        /// Редактирует название чата
        /// </summary>
        /// <param name="chat">Чат</param>
        /// <param name="newTitle">Новое название</param>
        /// <returns></returns>
        public async Task<bool> EditChat(Chat chat, string newTitle)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                new EditChat(
                    AccessToken: AuthData.AccessToken,
                    ChatID: chat.ID,
                    Title: newTitle
                ));

            return result != null;
        }

        /// <summary>
        /// Добавляет пользователя в чат
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="chat">Чат</param>
        /// <returns></returns>
        public async Task<bool> AddChatUser(User user, Chat chat)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                new AddChatUser(
                    AccessToken: AuthData.AccessToken,
                    ChatID: chat.ID,
                    UserID: user.ID
                ));

            return result == null ? false : result.Response == 1;
        }

        /// <summary>
        /// Удаляет пользователя из чата
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="chat">Чат</param>
        /// <returns></returns>
        public async Task<bool> RemoveChatUser(User user, Chat chat)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                new RemoveChatUser(
                    AccessToken: AuthData.AccessToken,
                    ChatID: chat.ID,
                    UserID: user.ID
                ));

            return result == null ? false : result.Response == 1;
        }

        /// <summary>
        /// Создает чат
        /// </summary>
        /// <param name="title">Название чата</param>
        /// <param name="users">Список пользователей</param>
        /// <returns></returns>
        public async Task<int> CreateChat(string title, IEnumerable<User> users)
        {
            var result = await _vkRequest.Dispath<VkResponse<int>>(
                new CreateChat(
                    AccessToken: AuthData.AccessToken,
                    Title: title,
                    UserIDs: users.Select(u => u.ID)
                ));

            return result == null ? 0 : result.Response;
        }
    }
}
