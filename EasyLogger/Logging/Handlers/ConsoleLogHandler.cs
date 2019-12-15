using System;
using EasyLogger.Format;
using EasyLogger.Format.Formatters;

namespace EasyLogger.Logging.Handlers
{
    public class ConsoleLogHandler : ILogHandler
    {
        public ConsoleLogHandler() : this(new DefaultLogFormatter())
        {
            
        }

        public ConsoleLogHandler(ILogFormatter formatter)
        {
            Formatter = formatter;
        }
        
        /// <summary>
        /// Log Formatter
        /// </summary>
        public ILogFormatter Formatter { get; }

        public void Log(LogMessage message)
        {
            switch(message.Level)
            {
                case ELogLevel.None:
                    WriteLine(Formatter.Format(message));
                    return;
                case ELogLevel.Debug:
                    WriteLine(Formatter.Format(message), ConsoleColor.Cyan);
                    return;
                case ELogLevel.Fine:
                    WriteLine(Formatter.Format(message), ConsoleColor.Green);
                    return;
                case ELogLevel.Info:
                    WriteLine(Formatter.Format(message), ConsoleColor.DarkGreen);
                    return;
                case ELogLevel.Warning:
                    WriteLine(Formatter.Format(message), ConsoleColor.Yellow);
                    return;
                case ELogLevel.Error:
                    WriteLine(Formatter.Format(message), ConsoleColor.Red);
                    return;
                case ELogLevel.Severe:
                    WriteLine(Formatter.Format(message), ConsoleColor.DarkRed);
                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// Write message to console
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="color">Message Color</param>
        private void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}