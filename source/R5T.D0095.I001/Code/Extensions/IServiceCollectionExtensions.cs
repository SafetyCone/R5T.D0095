using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

using R5T.D0093;
using R5T.D0095.D001;
using R5T.T0063;


namespace R5T.D0095.I001
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFileLoggerProvider(this IServiceCollection services,
            IServiceAction<ILogFilePathProvider> logFilePathProviderAction,
            IServiceAction<ILoggerSynchronicityProvider> loggerSynchonicityProviderAction)
        {
            services
                .Run(logFilePathProviderAction)
                .Run(loggerSynchonicityProviderAction)
                .TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, FileLoggerProvider>())
                ;

            return services;
        }
    }
}