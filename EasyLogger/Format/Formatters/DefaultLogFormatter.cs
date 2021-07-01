namespace EasyLogger.Format.Formatters
{
    /// <summary>
    /// Provide a basic <see cref="ILogFormatter"/> implementation.
    /// </summary>
    public class DefaultLogFormatter : ILogFormatter
    {
        public string Format(LogMessage message)
        {
            return $"[{message.Date:T}] [{message.Header}{message.Level}] > {message.Message}";
        }
    }
}