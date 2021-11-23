using System;
using System.IO;


namespace R5T.D0095.I001
{
    public class SynchronousFileLogMessageSink : IFileLogMessageSink
    {
        private TextWriter TextWriter { get; }


        public SynchronousFileLogMessageSink(
            TextWriter textWriter)
        {
            this.TextWriter = textWriter;
        }

        public void Dispose()
        {
            this.TextWriter.Dispose();

            GC.SuppressFinalize(this);
        }

        public void WriteLogMessage(string messageText)
        {
            // Use Write() not WriteLine() to allow caller to fully handle newline behavior.
            this.TextWriter.Write(messageText);
            this.TextWriter.Flush(); // Immediately flush.
        }
    }
}
