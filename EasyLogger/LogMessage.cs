using System;
using System.Collections.Generic;

namespace EasyLogger
{
    /// <summary>
    /// Represents a log message.
    /// </summary>
    public class LogMessage
    {
        public LogMessage(LogLevel level, string message, DateTime date, string messageHeader = null)
        {
            Level = level;
            Message = message;
            Header = messageHeader ?? "Logger/";
            Date = date;
        }

        /// <summary>
        ///     Log Level
        /// </summary>
        public LogLevel Level { get; }

        /// <summary>
        ///     Log Message
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Log Message Header
        /// </summary>
        public string Header { get; }

        /// <summary>
        ///     Log date
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        ///     Additional values
        /// </summary>
        private Dictionary<string, object> AdditionalValues { get; set; }

        /// <summary>
        ///     Get value from additional values
        /// </summary>
        /// <param name="key">Key</param>
        public object this[string key] => AdditionalValues.ContainsKey(key) ? AdditionalValues[key] : default;

        /// <summary>
        ///     Get value from additional values and try to cast it as <see cref="T" />
        /// </summary>
        /// <param name="key">Key</param>
        /// <typeparam name="T">Return type</typeparam>
        /// <returns><see cref="T" /> if the value exists and the provided type is the same as the value, default type value otherwise.</returns>
        public T GetValueAs<T>(string key) where T : class
        {
            return this[key] as T;
        }

        /// <summary>
        ///     Add additional string value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void AddStringValue(string key, string value)
        {
            AdditionalValues ??= new Dictionary<string, object>();
            AdditionalValues.Add(key, value);
        }

        /// <summary>
        ///     Add additional string values
        /// </summary>
        /// <param name="values">Values</param>
        public void AddAdditionalValues(params (string Key, object Value)[] values)
        {
            if (values == null)
                return;
            for (var i = 0; i < values.Length; i++)
                AdditionalValues.Add(values[i].Key, values[i].Value);
        }

        /// <summary>
        ///     Remove string from additional values
        /// </summary>
        /// <param name="key">Key</param>
        public void RemoveStringValue(string key)
        {
            if (!AdditionalValues.ContainsKey(key))
                return;
            AdditionalValues.Remove(key);
        }

        public override string ToString()
        {
            return $"[{Date:T}] [{Level}] > {Message}";
        }
    }
}