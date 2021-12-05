using System;
using System.Threading.Tasks;

using R5T.D0048;
using R5T.T0064;


namespace R5T.D0095.D001.I002
{
    [ServiceImplementationMarker]
    public class LogFilePathProvider : ILogFilePathProvider, IServiceImplementation
    {
        private ILogFileNameProvider LogFileNameProvider { get; }
        private IOutputFilePathProvider OutputFilePathProvider { get; }


        public LogFilePathProvider(
            ILogFileNameProvider logFileNameProvider,
            IOutputFilePathProvider outputFilePathProvider)
        {
            this.LogFileNameProvider = logFileNameProvider;
            this.OutputFilePathProvider = outputFilePathProvider;
        }

        public async Task<string> GetLogFilePath()
        {
            var logFileName = await this.LogFileNameProvider.GetLogFileName();

            var output = await this.OutputFilePathProvider.GetOutputFilePath(logFileName);
            return output;
        }
    }
}
