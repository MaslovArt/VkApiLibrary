using VkApiSDK.Requests;

namespace VkApiSDK.Abstraction
{
    public abstract class VkApiMethodGroup
    {
        protected IVkRequest _vkRequest;

        /// <summary>
        /// Инициализирует новый экземпляр класса <c>VkApiMethodGroup</c>
        /// </summary>
        /// <param name="AuthData">Токен доступа</param>
        /// <param name="VkRequest">Класс для отправки запросов</param>
        public VkApiMethodGroup(AuthData AuthData, IVkRequest VkRequest = null)
        {
            this.AuthData = AuthData;
            _vkRequest = VkRequest ?? new VkRequest();
        }

        /// <summary>
        /// Токен доступа
        /// </summary>
        public AuthData AuthData { get; private set; }
    }
}
