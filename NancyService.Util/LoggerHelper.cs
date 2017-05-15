using NLog;

namespace WorkData.Util
{
    public class LoggerHelper
    {
        public static volatile ILogger BusinessLog = LogManager.GetLogger("businessLog");
        public static volatile ILogger SystemLog = LogManager.GetLogger("systemLog");
        public static volatile ILogger ApiLog = LogManager.GetLogger("apilog");
        public static volatile ILogger DbLog = LogManager.GetLogger("db");

    }
}
