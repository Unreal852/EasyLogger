using System;

namespace EasyLogger
{
    public interface ILogger
    {
        /// <summary>
        /// Log a new message.
        /// This will use the default log level.
        /// </summary>
        /// <param name="message">Message to log</param>
        public void Log(string message);

        /// <summary>
        /// Log a new message with a custom log level.
        /// </summary>
        /// <param name="level">Log Level</param>
        /// <param name="message">Message to log</param>
        public void Log(ELogLevel level, string message);

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="ex">Exception to log</param>
        public void Log(Exception ex);

        /// <summary>
        /// Log a new message, with a custom log level, header, and additional values.
        /// </summary>
        /// <param name="level">Log Level</param>
        /// <param name="message">Message to log</param>
        /// <param name="header">Log Header</param>
        /// <param name="additionalValues">Additional Values</param>
        public void Log(ELogLevel level, string message, string header,
            params (string Key, string Value)[] additionalValues);
    }
}