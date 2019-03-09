namespace VkApiSDK.Abstraction
{
    public interface IVkApiMethod
    {
        /// <summary>
        /// Возвращает строку для api запроса.
        /// </summary>
        /// <returns>Uri</returns>
        string GetRequestString();
    }
}
