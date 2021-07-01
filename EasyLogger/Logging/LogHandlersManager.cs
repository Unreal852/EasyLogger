using System;
using System.Collections.Generic;
using EasyLogger.Logging.Handlers;

namespace EasyLogger.Logging
{
    /// <summary>
    ///     Provide a basic <see cref="ILogHandlersManager" /> implementation.
    /// </summary>
    public class LogHandlersManager : ILogHandlersManager
    {
        public LogHandlersManager(bool storeMessages = false)
        {
            StoreMessages = storeMessages;
        }

        /// <summary>
        ///     If set to true, messages will be stored.
        /// </summary>
        public bool StoreMessages { get; set; }

        /// <summary>
        ///     Returns stored messages
        /// </summary>
        public IEnumerable<LogMessage> Messages => StoredMessages;

        /// <summary>
        ///     Stored Messages
        /// </summary>
        private List<LogMessage> StoredMessages { get; } = new();

        /// <summary>
        ///     Handlers
        /// </summary>
        private List<ILogHandler> Handlers { get; } = new();
        
        public ILogHandlersManager AddHandler(ILogHandler handler)
        {
            if (handler == null)
                return this;
            Handlers.Add(handler);
            return this;
        }
        
        public ILogHandlersManager AddHandler(ILogHandler handler, Predicate<LogMessage> filter)
        {
            if (handler == null || filter == null)
                return this;
            return AddHandler(new FilteredHandler(handler, filter));
        }

        /// <summary>
        ///     Unregister the specified <see cref="ILogHandler" />.
        /// </summary>
        /// <param name="handler">The <see cref="ILogHandler" /> to unregister.</param>
        /// <returns>true of the specified <see cref="ILogHandler" /> was unregistered, false otherwise.</returns>
        public bool RemoveHandler(ILogHandler handler)
        {
            return Handlers.Remove(handler);
        }

        public void Log(LogMessage message)
        {
            foreach (ILogHandler logHandler in Handlers)
                logHandler.Log(message);
            if (StoreMessages)
                StoredMessages.Add(message);
        }
    }
}