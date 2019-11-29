using System;
using EasyLogger.Format;
using EasyLogger.Format.Formatters;

namespace EasyLogger.Logging.Handlers
{
    public class ConsoleLogHandler : ILogHandler
    {
        public ConsoleLogHandler()
        {
            
        }
        
        /// <summary>
        /// Log Formatter
        /// </summary>
        public ILogFormatter Formatter { get; } = new DefaultLogFormatter();

        public void Log(LogMessage message)
        {
            switch(message.Level)
            {
                case LogLevel.None:
                    WriteLine(Formatter.Format(message));
                    return;
                case LogLevel.Debug:
                    WriteLine(Formatter.Format(message), ConsoleColor.Cyan);
                    return;
                case LogLevel.Fine:
                    WriteLine(Formatter.Format(message), ConsoleColor.Green);
                    return;
                case LogLevel.Info:
                    WriteLine(Formatter.Format(message), ConsoleColor.DarkGreen);
                    return;
                case LogLevel.Warning:
                    WriteLine(Formatter.Format(message), ConsoleColor.Yellow);
                    return;
                case LogLevel.Error:
                    WriteLine(Formatter.Format(message), ConsoleColor.Red);
                    return;
                case LogLevel.Severe:
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