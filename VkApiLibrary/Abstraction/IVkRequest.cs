using System;
using System.Threading.Tasks;
using VkApiSDK.Models.Errors;

namespace VkApiSDK.Abstraction
{
    public interface IVkRequest
    {
        Task<T> Dispath<T>(IVkApiMethod vkApiMethod, Action<Error> OnRequestError = null) where T : class;
    }
}
