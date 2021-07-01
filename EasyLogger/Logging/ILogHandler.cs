namespace EasyLogger.Logging
{
    public interface ILogHandler
    {
        /// <summary>
        ///     Called when a new log message arrives
        /// </summary>
        /// <param name="message">Log Message</param>
        void Log(LogMessage message);
    }
}