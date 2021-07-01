using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyLogger.Format;
using EasyLogger.Format.Formatters;
using EasyLogger.Logging;
using EasyLogger.Logging.Handlers;

namespace EasyLogger.Sample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Shown += OnShown;
            BtnLog.Click += BtnLogOnClick;
            BtnOpenFile.Click += BtnOpenFileOnClick;
            TxtLogMessage.KeyDown += TxtLogMessageOnKeyDown;

            var fileLogHandler = new FileLogHandler();
            LogFile = fileLogHandler.File;
            Logger.HandlersManager.AddHandler(new CustomLogHandler(LstLogs)).AddHandler(new DebugLogHandler()).AddHandler(fileLogHandler);
        }

        private Logger   Logger  { get; } = new();
        private FileInfo LogFile { get; }

        private void Log()
        {
            LogLevel logLevel = (LogLevel) CmbLogLevel.SelectedItem;
            string log = TxtLogMessage.Text;
            if (string.IsNullOrWhiteSpace(log))
                return;
            Logger.Log(logLevel, log);
            TxtLogMessage.Clear();
        }

        private void OnShown(object sender, EventArgs e)
        {
            foreach (LogLevel logLevel in Enum.GetValues(typeof(LogLevel)))
                CmbLogLevel.Items.Add(logLevel);
            CmbLogLevel.SelectedIndex = 0;
        }

        private void BtnLogOnClick(object sender, EventArgs e)
        {
            Log();
        }

        private void BtnOpenFileOnClick(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(LogFile.FullName) {UseShellExecute = true});
        }

        private void TxtLogMessageOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Log();
            }
        }
    }

    public class CustomLogHandler : ILogHandler
    {
        public CustomLogHandler(ListBox listBox)
        {
            ListBoxLogs = listBox;
        }

        private ILogFormatter Formatter   { get; } = new DefaultLogFormatter();
        private ListBox       ListBoxLogs { get; }

        public void Log(LogMessage message)
        {
            ListBoxLogs.Items.Add(Formatter.Format(message));
        }
    }
}