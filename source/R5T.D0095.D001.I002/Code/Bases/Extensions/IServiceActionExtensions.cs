using System;

using R5T.D0048;
using R5T.T0062;
using R5T.T0063;


namespace R5T.D0095.D001.I002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="LogFilePathProvider"/> implementation of <see cref="ILogFilePathProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ILogFilePathProvider> AddLogFilePathProviderAction(this IServiceAction _,
            IServiceAction<ILogFileNameProvider> logFileNameProviderAction,
            IServiceAction<IOutputFilePathProvider> outputFilePathProviderAction)
        {
            var serviceAction = _.New<ILogFilePathProvider>(services => services.AddLogFilePathProvider(
                logFileNameProviderAction,
                outputFilePathProviderAction));

            return serviceAction;
        }
    }
}
