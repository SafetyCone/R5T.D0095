using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0095.D001.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConstructorBasedLogFilePathProvider"/> implementation of <see cref="ILogFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedLogFilePathProvider(this IServiceCollection services,
            string logFilePath)
        {
            services.AddSingleton<ILogFilePathProvider>(new ConstructorBasedLogFilePathProvider(
                logFilePath));

            return services;
        }
    }
}