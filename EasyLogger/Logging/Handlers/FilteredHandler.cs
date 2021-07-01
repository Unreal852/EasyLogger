using System;

namespace EasyLogger.Logging.Handlers
{
    /// <summary>
    /// Provide a basic <see cref="LogMessage"/> filter.
    /// </summary>
    public class FilteredHandler : ILogHandler
    {
        public FilteredHandler(ILogHandler handler, Predicate<LogMessage> filter)
        {
            Handler = handler;
            Filter = filter;
        }

        public ILogHandler Handler { get; }

        public Predicate<LogMessage> Filter { get; }

        public void Log(LogMessage message)
        {
            if (Filter(message))
                Handler.Log(message);
        }
    }
}