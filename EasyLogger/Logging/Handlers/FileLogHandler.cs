using System;
using System.IO;
using EasyLogger.Format;
using EasyLogger.Format.Formatters;

namespace EasyLogger.Logging.Handlers
{
    public class FileLogHandler : ILogHandler
    {
        public FileLogHandler() : this(CreateFileName())
        {
            
        }

        public FileLogHandler(string fileName) : this(fileName, string.Empty)
        {
            
        }

        public FileLogHandler(string fileName, string directory) : this(new DefaultLogFormatter(), fileName, directory)
        {
            
        }

        public FileLogHandler(ILogFormatter loggerFormatter) : this(loggerFormatter, CreateFileName())
        {
            
        }

        public FileLogHandler(ILogFormatter loggerFormatter, string fileName) : this(loggerFormatter, fileName,
            string.Empty)
        {
            
        }

        public FileLogHandler(ILogFormatter loggerFormatter, string fileName, string directory)
        {
            Formatter = loggerFormatter;
            FileName = fileName;
            Directory = string.IsNullOrEmpty(directory) ? new DirectoryInfo(Path.Combine(directory)) : new DirectoryInfo(directory);
            if(!Directory.Exists)
                Directory.Create();
        }
        
        /// <summary>
        /// Formatter
        /// </summary>
        private ILogFormatter Formatter { get; }
        
        /// <summary>
        /// Directory
        /// </summary>
        private DirectoryInfo Directory { get; }
        
        /// <summary>
        /// File Name
        /// </summary>
        private string FileName { get; }

        public void Log(LogMessage logMessage)
        {
            using StreamWriter writer = new StreamWriter(File.Open(Path.Combine(Directory.FullName, FileName), FileMode.Append));
            writer.WriteLine(Formatter.Format(logMessage));
        }
        
        /// <summary>
        /// Generate File Name
        /// </summary>
        /// <returns></returns>
        private static string CreateFileName()
        {
            DateTime currentDate = DateTime.Now;
            Guid guid = Guid.NewGuid();
            return $"Log_{currentDate.Year:0000}{currentDate.Month:00}{currentDate.Day:00}-{currentDate.Hour:00}{currentDate.Minute:00}_{guid}.log";
        }
    }
}