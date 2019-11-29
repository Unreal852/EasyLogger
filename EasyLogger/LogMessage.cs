using System;
using System.Collections.Generic;

namespace EasyLogger
{
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
        /// Log Level
        /// </summary>
        public LogLevel Level { get; }
        
        /// <summary>
        /// Log Message
        /// </summary>
        public string Message { get; }
        
        /// <summary>
        /// Log Message Header
        /// </summary>
        public string Header { get; }

        /// <summary>
        /// Log date
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Additional string values
        /// </summary>
        private Dictionary<string, string> AdditionalValues { get; set; }

        /// <summary>
        /// Add additional string value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void AddStringValue(string key, string value)
        {
            if(AdditionalValues == null)
                AdditionalValues = new Dictionary<string, string>();
            AdditionalValues.Add(key, value);
        }

        /// <summary>
        /// Get string value from additional values
        /// </summary>
        /// <param name="key">Key</param>
        public string this[string key]
        {
            get => AdditionalValues.ContainsKey(key) ? AdditionalValues[key] : default(string);
        }

        /// <summary>
        /// Remove string from additional values
        /// </summary>
        /// <param name="key">Key</param>
        public void RemoveStringValue(string key)
        {
            if(!AdditionalValues.ContainsKey(key))
                return;
            AdditionalValues.Remove(key);
        }

        public override string ToString()
        {
            return $"[{Date:T}] [{Level}] > {Message}";
        }
    }
}