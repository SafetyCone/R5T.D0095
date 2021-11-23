using System;
using System.IO;

using Microsoft.Extensions.Logging;

using R5T.D0093;
using R5T.T0064;

using R5T.D0095.D001;


namespace R5T.D0095.I001
{
    [ServiceImplementationMarker]
    public class FileLoggerProvider : IFileLoggerProvider, IServiceImplementation
    {
        #region Static

        private static void PerformFirstTimeSetup(FileLoggerProvider fileLoggerProvider)
        {
            SyncOverAsyncHelper.ExecuteSynchronously(async () =>
            {
                var gettingLoggerSynchronicity = fileLoggerProvider.LoggerSynchonicityProvider.GetLoggerSynchronicity();
                var gettingLogFilePath = fileLoggerProvider.LogFilePathProvider.GetLogFilePath();

                var loggerSynchronicity = await gettingLoggerSynchronicity;
                var logFilePath = await gettingLogFilePath;

                var textWriter = new StreamWriter(logFilePath);

                var isSynchronous = loggerSynchronicity.IsSynchronous();
                if(isSynchronous)
                {
                    fileLoggerProvider.FileLogMessageSink = new SynchronousFileLogMessageSink(textWriter);
                }
                else
                {
                    fileLoggerProvider.FileLogMessageSink = new AsynchronousFileLogMessageSink(textWriter);
                }
            });
        }

        private static void EnsureIsSetup(FileLoggerProvider fileLoggerProvider)
        {
            var isSetup = fileLoggerProvider.FileLogMessageSink is object;
            if (!isSetup)
            {
                FileLoggerProvider.PerformFirstTimeSetup(fileLoggerProvider);
            }
        }

        #endregion


        private ILogFilePathProvider LogFilePathProvider { get; }
        private ILoggerSynchronicityProvider LoggerSynchonicityProvider { get; }

        private IFileLogMessageSink FileLogMessageSink { get; set; }


        public FileLoggerProvider(
            ILogFilePathProvider logFilePathProvider,
            ILoggerSynchronicityProvider loggerSynchonicityProvider)
        {
            this.LogFilePathProvider = logFilePathProvider;
            this.LoggerSynchonicityProvider = loggerSynchonicityProvider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            FileLoggerProvider.EnsureIsSetup(this);

            var output = new FileLogger(
                categoryName,
                this.FileLogMessageSink);

            return output;
        }

        public void Dispose()
        {
            this.FileLogMessageSink.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}