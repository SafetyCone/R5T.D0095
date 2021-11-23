using System;

using Microsoft.Extensions.Logging;

using R5T.T0064;


namespace R5T.D0095
{
    [ServiceDefinitionMarker]
    public interface IFileLoggerProvider : ILoggerProvider, IServiceDefinition
    {
    }
}