using System;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

using R5T.D0093;
using R5T.D0095.D001;
using R5T.T0063;


namespace R5T.D0095.I001
{
    public static class ILoggingBuilderExtensions
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder loggingBuilder,
            IServiceAction<ILogFilePathProvider> logFilePathProviderAction,
            IServiceAction<ILoggerSynchronicityProvider> loggerSynchonicityProviderAction)
        {
            loggingBuilder.AddConfiguration();

            loggingBuilder.Services.AddFileLoggerProvider(
                logFilePathProviderAction,
                loggerSynchonicityProviderAction);

            return loggingBuilder;
        }
    }
}
