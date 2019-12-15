namespace EasyLogger.Format.Formatters
{
    public class DefaultLogFormatter : ILogFormatter
    {
        public DefaultLogFormatter()
        {
        }

        public string Format(LogMessage message)
        {
            return $"[{message.Date:T}] [{message.Header}{message.Level}] > {message.Message}";
        }
    }
}