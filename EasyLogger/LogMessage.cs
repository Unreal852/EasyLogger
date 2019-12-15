using System;
using System.Collections.Generic;

namespace EasyLogger
{
    public class LogMessage
    {
        public LogMessage(ELogLevel level, string message, DateTime date, string messageHeader = null)
        {
            Level = level;
            Message = message;
            Header = messageHeader ?? "Logger/";
            Date = date;
        }
        
        /// <summary>
        /// Log Level
        /// </summary>
        public ELogLevel Level { get; }
        
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
        /// Add additional string values
        /// </summary>
        /// <param name="values">Values</param>
        public void AddStringValues(params (string Key, string Value)[] values)
        {
            if (values == null)
                return;
            for(int i = 0; i < values.Length; i++)
                AdditionalValues.Add(values[i].Key, values[i].Value);
        }

        /// <summary>
        /// Get string value from additional values
        /// </summary>
        /// <param name="key">Key</param>
        public string this[string key] => AdditionalValues.ContainsKey(key) ? AdditionalValues[key] : default;

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