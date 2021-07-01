using System;

namespace EasyLogger.Logging
{
    public interface ILogHandlersManager
    {
        /// <summary>
        ///     Register a new <see cref="ILogHandler" />.
        /// </summary>
        /// <param name="logHandler">
        ///     <see cref="ILogHandler" />
        /// </param>
        /// <returns>
        ///     <see cref="ILogHandlersManager" />
        /// </returns>
        ILogHandlersManager AddHandler(ILogHandler logHandler);

        /// <summary>
        ///     Register a new <see cref="ILogHandler" /> that will only handle specific <see cref="LogMessage" /> filtered by the provided <see cref="Predicate{LogMessage}" />
        /// </summary>
        /// <param name="logHandler">The <see cref="ILogHandler" /> to register.</param>
        /// <param name="messageFilter">The <see cref="Predicate{T}" /> used to filter messages.</param>
        /// <returns>
        ///     <see cref="ILogHandlersManager" />
        /// </returns>
        ILogHandlersManager AddHandler(ILogHandler logHandler, Predicate<LogMessage> messageFilter);

        /// <summary>
        ///     Unregister the specified <see cref="ILogHandler" />.
        /// </summary>
        /// <param name="handler">The <see cref="ILogHandler" /> to unregister.</param>
        /// <returns>true of the specified <see cref="ILogHandler" /> was unregistered, false otherwise.</returns>
        bool RemoveHandler(ILogHandler logHandler);

        /// <summary>
        ///     Log a new message
        /// </summary>
        /// <param name="message">Log Message</param>
        void Log(LogMessage message);
    }
}