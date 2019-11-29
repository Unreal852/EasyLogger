using System;
using System.Collections.Generic;
using EasyLogger.Logging.Handlers;

namespace EasyLogger.Logging
{
    public class LogHandlersManager : ILogHandlersManager
    {
        public LogHandlersManager(bool storeMessages = false)
        {
            StoreMessages = storeMessages;
        }
        
        /// <summary>
        /// If set to true, messages will be stored.
        /// </summary>
        public bool StoreMessages { get; set; }

        /// <summary>
        /// Returns stored messages
        /// </summary>
        public IEnumerable<LogMessage> Messages => StoredMessages;
        
        /// <summary>
        /// Stored Messages
        /// </summary>
        private List<LogMessage> StoredMessages { get; } = new List<LogMessage>();
        
        /// <summary>
        /// Handlers
        /// </summary>
        private List<ILogHandler> Handlers { get; } = new List<ILogHandler>();
        
        public ILogHandlersManager AddHandler(ILogHandler handler)
        {
            if(handler == null)
                return this;
            Handlers.Add(handler);
            return this;
        }

        public ILogHandlersManager AddHandler(ILogHandler handler, Predicate<LogMessage> filter)
        {
            if(handler == null || filter == null)
                return this;
            return AddHandler(new FilteredHandler(handler, filter));
        }

        public bool RemoveHandler(ILogHandler handler)
        {
            return Handlers.Remove(handler);
        }

        public void Log(LogMessage message)
        {
            if(StoreMessages)
                StoredMessages.Add(message);
            foreach(ILogHandler logHandler in Handlers)
                logHandler.Log(message);
        }
    }
}