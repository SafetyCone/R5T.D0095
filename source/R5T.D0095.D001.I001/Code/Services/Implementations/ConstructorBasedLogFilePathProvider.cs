using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0095.D001.I001
{
    [ServiceImplementationMarker]
    public class ConstructorBasedLogFilePathProvider : ILogFilePathProvider, IServiceImplementation
    {
        private string LogFilePath { get; set; }


        public ConstructorBasedLogFilePathProvider(
            string logFilePath)
        {
            this.LogFilePath = logFilePath;
        }

        public Task<string> GetLogFilePath()
        {
            return Task.FromResult(this.LogFilePath);
        }
    }
}