using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0048;
using R5T.T0063;


namespace R5T.D0095.D001.I002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="LogFilePathProvider"/> implementation of <see cref="ILogFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddLogFilePathProvider(this IServiceCollection services,
            IServiceAction<ILogFileNameProvider> logFileNameProviderAction,
            IServiceAction<IOutputFilePathProvider> outputFilePathProviderAction)
        {
            services
                .Run(logFileNameProviderAction)
                .Run(outputFilePathProviderAction)
                .AddSingleton<ILogFilePathProvider, LogFilePathProvider>();

            return services;
        }
    }
}