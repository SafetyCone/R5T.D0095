using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0095.D001
{
    [ServiceDefinitionMarker]
    public interface ILogFileNameProvider : IServiceDefinition
    {
        Task<string> GetLogFileName();
    }
}
