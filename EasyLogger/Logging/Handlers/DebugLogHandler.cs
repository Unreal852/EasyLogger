using System.Diagnostics;
using EasyLogger.Format;
using EasyLogger.Format.Formatters;

namespace EasyLogger.Logging.Handlers
{
    public class DebugLogHandler : ILogHandler
    {
        public DebugLogHandler() : this(new DefaultLogFormatter())
        {
            
        }

        public DebugLogHandler(ILogFormatter formatter)
        {
            Formatter = formatter;
        }
        
        /// <summary>
        /// Log Formatter
        /// </summary>
        public ILogFormatter Formatter { get; }

        public void Log(LogMessage message)
        {
            Debug.WriteLine(Formatter.Format(message));
        }
    }
}