using System;

using Microsoft.Extensions.Logging;

using R5T.L0017.T002;


namespace R5T.D0095.I001
{
    public class FileLogger : LoggerBase
    {
        private IFileLogMessageSink FileLogMessageSink { get; }


        public FileLogger(string categoryName,
            IFileLogMessageSink fileLogMessageSink)
            : base(categoryName)
        {
            this.FileLogMessageSink = fileLogMessageSink;
        }

        public override void WriteMessage(LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            var messageText = Instances.LoggerOperator.GetLogMessageText(
                logLevel, logName, eventId, message, exception);

            this.FileLogMessageSink.WriteLogMessage(messageText);
        }
    }
}
