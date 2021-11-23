using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0095.D001.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConstructorBasedLogFilePathProvider"/> implementation of <see cref="ILogFilePathProvider"/>.
        /// </summary>
        public static IServiceAction<ILogFilePathProvider> AddConstructorBasedLogFilePathProvider(this IServiceAction _,
            string logFilePath)
        {
            var output = _.New<ILogFilePathProvider>(services => services.AddConstructorBasedLogFilePathProvider(
                logFilePath));

            return output;
        }
    }
}
