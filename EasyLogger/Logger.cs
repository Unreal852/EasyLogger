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
        public ELogLevel DefaultLogLevel { get; set; } = ELogLevel.Info;

        /// <summary>
        /// Default header
        /// </summary>
        public string Header { get; set; } = "Logger/";

        /// <summary>
        /// If set to false, logging will be disabled
        /// </summary>
        public bool Enabled { get; set; } = true;

        public void Log(string message)
        {
            Log(DefaultLogLevel, message, Header, null);
        }

        public void Log(ELogLevel level, string message)
        {
            Log(level, message, Header, null);
        }

        public void Log(Exception ex)
        {
            Log(ELogLevel.Error, $"{ex.Message} {Environment.NewLine} {ex.StackTrace}", Header, null);
        }

        public void Log(ELogLevel level, string message, string header, params (string Key, string Value)[] additionalValues)
        {
            if(!Enabled)
                return;
            LogMessage logMsg = new LogMessage(level, message, DateTime.Now, header ?? Header);
            logMsg.AddStringValues(additionalValues);
            HandlersManager.Log(logMsg);
        }
    }
}