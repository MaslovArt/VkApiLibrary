using System.Threading.Tasks;
using VkApiSDK.Utils;

namespace VkApiSDK.Abstraction
{
    public interface IVkRequest
    {
        ILogger Logger { get; set; }
        int Timeout { get; set; }
        Task<T> Dispath<T>(IVkApiMethod vkApiMethod) where T : IVkResponse;
    }
}
