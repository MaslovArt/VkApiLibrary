using System;

namespace VkApiSDK.Utils
{
    public interface ILogger
    {
        void WriteInfo(string msg, int level);

        void WriteException(string msg, Exception ex);
    }
}
