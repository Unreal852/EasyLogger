using System;
using EasyLogger.Logging;

namespace EasyLogger
{
    public class Logger : ILogger
    {
         public Logger(ILogHandlersManager logHandlersManager = null)
        {
            HandlersManager = logHandlersManager ?? new LogHandlersManager();
        }

        public ILogHandlersManager HandlersManager { get; }

        /// <summary>
        /// Default log level
        /// </summary>
        public LogLevel DefaultLevel { get; set; } = LogLevel.Info;

        /// <summary>
        /// Default header
        /// </summary>
        public string DefaultHeader { get; set; } = "Logger/";

        /// <summary>
        /// If set to false, logging will be disabled
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Enable logger
        /// </summary>
        public void On()
        {
            Enabled = true;
        }

        /// <summary>
        /// Disable logger
        /// </summary>
        public void Off()
        {
            Enabled = false;
        }

        public void Log(string message, string header = null)
        {
            Log(DefaultLevel, message, header ?? DefaultHeader, null);
        }

        public void Log(LogLevel level, string message, string header = null)
        {
            Log(level, message, header ?? DefaultHeader, null);
        }

        public void Log(Exception ex, string header = null)
        {
            Log(LogLevel.Error, $"{ex.Message} {Environment.NewLine} {ex.StackTrace}", header ?? DefaultHeader, null);
        }

        public void Log(LogLevel level, string message, string header, params (string Key, string Value)[] additionalValues)
        {
            if(!Enabled)
                return;
            LogMessage logMsg = new LogMessage(level, message, DateTime.Now, header ?? DefaultHeader);
            if(additionalValues != null)
            {
                foreach((string Key, string Value) values in additionalValues)
                    logMsg.AddStringValue(values.Key, values.Value);
            }

            HandlersManager.Log(logMsg);
        }
    }
}