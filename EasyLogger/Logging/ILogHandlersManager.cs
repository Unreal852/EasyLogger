using System;

namespace EasyLogger.Logging
{
    public interface ILogHandlersManager
    {
        /// <summary>
        /// Add a new handler
        /// </summary>
        /// <param name="logHandler">Log Handler</param>
        /// <returns><see cref="ILogHandlersManager"/> so you can chain calls</returns>
        ILogHandlersManager AddHandler(ILogHandler logHandler);
        
        /// <summary>
        /// Add a new handler
        /// </summary>
        /// <param name="logHandler">Log Handler</param>
        /// <param name="messageFilter">Message Filter</param>
        /// <returns><see cref="ILogHandlersManager"/> so you can chain calls</returns>
        ILogHandlersManager AddHandler(ILogHandler logHandler, Predicate<LogMessage> messageFilter);

        /// <summary>
        /// Log a new message
        /// </summary>
        /// <param name="message">Log Message</param>
        void Log(LogMessage message);

        /// <summary>
        /// Remove log handler
        /// </summary>
        /// <param name="logHandler">Log Handler to remove</param>
        /// <returns>trueif the handler has been removed, false otherwise</returns>
        bool RemoveHandler(ILogHandler logHandler);
    }
}