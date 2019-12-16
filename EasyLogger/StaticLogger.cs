using System;

namespace EasyLogger
{
    /// <summary>
    /// Provide a public static logger
    /// </summary>
    public static class StaticLogger
    {
        static StaticLogger()
        {
            Logger = new Logger();
        }
        
        public static Logger Logger { get; }

        /// <summary>
        /// Log a new message.
        /// This will use the default log level.
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Log(string message) => Logger.Log(message);

        /// <summary>
        /// Log a new message with a custom log level.
        /// </summary>
        /// <param name="level">Log Level</param>
        /// <param name="message">Message to log</param>
        public static void Log(ELogLevel level, string message) => Logger.Log(level, message);

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="ex">Exception to log</param>
        public static void Log(Exception ex) => Logger.Log(ex);

        /// <summary>
        /// Log a new message, with a custom log level, header, and additional values.
        /// </summary>
        /// <param name="level">Log Level</param>
        /// <param name="message">Message to log</param>
        /// <param name="header">Log Header</param>
        /// <param name="additionalValues">Additional Values</param>
        public static void Log(ELogLevel level, string message, string header,
            params (string Key, string Value)[] additionalValues) =>
            Logger.Log(level, message, header, additionalValues);
    }
}