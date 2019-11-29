namespace EasyLogger.Format
{
    public interface ILogFormatter
    {
        /// <summary>
        /// Format the specified <see cref="LogMessage"/> into a formatted <see cref="string"/>
        /// </summary>
        /// <param name="message">Message to format</param>
        /// <returns>Formatted <see cref="string"/></returns>
        string Format(LogMessage message);
    }
}