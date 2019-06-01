using ICN.Interface;
using NLog;
namespace ICN.Generic
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Information(string message)
        {

            logger.Info(message);
        }

        public void Warning(string message)
        {

            logger.Warn(message);
        }

    }
}
