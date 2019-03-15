using VkApiSDK.Models.Errors;

namespace VkApiSDK.Abstraction
{
    public interface IVkResponse
    {
        bool IsSucceed { get; }

        void SetError(Error Error);
    }
}
