using System;
using System.IO;
using EasyLogger.Format;
using EasyLogger.Format.Formatters;

namespace EasyLogger.Logging.Handlers
{
    /// <summary>
    /// Provide a basic file logger (<see cref="ILogHandler"/>) implementation.
    /// </summary>
    public class FileLogHandler : ILogHandler
    {
        public FileLogHandler() : this(new DefaultLogFormatter())
        {
        }

        public FileLogHandler(ILogFormatter loggerFormatter) : this(loggerFormatter, CreateFileName())
        {
        }

        public FileLogHandler(ILogFormatter loggerFormatter, string directory) : this(loggerFormatter, CreateFileName(), directory)
        {
        }

        public FileLogHandler(ILogFormatter loggerFormatter, string fileName, string directory)
        {
            Formatter = loggerFormatter;
            Directory = new DirectoryInfo(string.IsNullOrWhiteSpace(directory) ? Environment.CurrentDirectory : directory);
            if (!Directory.Exists)
                Directory.Create();
            File = new FileInfo(Path.Combine(Directory.FullName, fileName));
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
        /// File
        /// </summary>
        public FileInfo File { get; }

        public void Log(LogMessage logMessage)
        {
            using var writer = new StreamWriter(File.Open(FileMode.Append));
            writer.WriteLine(Formatter.Format(logMessage));
        }

        /// <summary>
        /// Generate File Name
        /// </summary>
        /// <returns>File Name</returns>
        private static string CreateFileName()
        {
            DateTime currentDate = DateTime.Now;
            var guid = Guid.NewGuid();
            return $"Log_{currentDate.Year:0000}.{currentDate.Month:00}.{currentDate.Day:00}-{currentDate.Hour:00}.{currentDate.Minute:00}_{guid}.log";
        }
    }
}