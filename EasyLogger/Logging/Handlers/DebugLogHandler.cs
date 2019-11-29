using System.Diagnostics;
using EasyLogger.Format;
using EasyLogger.Format.Formatters;

namespace EasyLogger.Logging.Handlers
{
    public class DebugLogHandler : ILogHandler
    {
        public DebugLogHandler()
        {
            
        }
        
        /// <summary>
        /// Log Formatter
        /// </summary>
        public ILogFormatter Formatter { get; } = new DefaultLogFormatter();

        public void Log(LogMessage message)
        {
            Debug.WriteLine(Formatter.Format(message));
        }
    }
}