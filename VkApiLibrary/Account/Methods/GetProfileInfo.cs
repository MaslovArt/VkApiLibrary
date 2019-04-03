using VkApiSDK.Abstraction;

namespace VkApiSDK.Account.Methods
{
    /// <summary>
    /// Возвращает информацию о текущем профиле.
    /// </summary>
    public class GetProfileInfo : VkApiMethod
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <c>GetProfileInfo</c>
        /// </summary>
        /// <param name="AccessToken">Токен доступа</param>
        public GetProfileInfo(string AccessToken)
            :base(AccessToken)
        {
            VkApiMethodName = "account.getProfileInfo";
        }

        protected override string GetMethodApiParams()
        {
            return string.Empty;
        }
    }
}
