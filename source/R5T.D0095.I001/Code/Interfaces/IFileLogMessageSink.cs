using System;


namespace R5T.D0095.I001
{
    public interface IFileLogMessageSink : IDisposable
    {
        void WriteLogMessage(string messageText);
    }
}
