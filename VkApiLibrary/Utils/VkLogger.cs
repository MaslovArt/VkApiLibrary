using System;
using System.Diagnostics;

namespace VkApiSDK.Utils
{
    public class VkLogger : ILogger
    {
        public string CurrentTime => DateTime.Now.ToString("HH: mm:ss");

        public void WriteException(string msg, Exception ex)
        {
            Debug.WriteLine($"Exception time:{CurrentTime} - {msg}");
        }

        public void WriteInfo(string msg, int level)
        {
            var levelString = level == 1 ? "Info" : "Error";
            Debug.WriteLine($"{levelString} time:{CurrentTime} - {msg}");
        }
    }

    public enum LogLevel
    {
        Info,
        Error,
        Exception
    }
}
