using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0095.D001.I001
{
    [ServiceImplementationMarker]
    public class ConstructorBasedLogFileNameProvider : ILogFileNameProvider, IServiceImplementation
    {
        private string LogFileName { get; }


        public ConstructorBasedLogFileNameProvider(
            string logFileName)
        {
            this.LogFileName = logFileName;
        }

        public Task<string> GetLogFileName()
        {
            return Task.FromResult(this.LogFileName);
        }
    }
}
