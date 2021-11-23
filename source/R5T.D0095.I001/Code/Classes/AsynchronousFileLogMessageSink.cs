using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;


namespace R5T.D0095.I001
{
    public class AsynchronousFileLogMessageSink : IFileLogMessageSink
    {
        private const int MaximumQueuedMessageCount = 1024;


        private BlockingCollection<string> LogMessageCollection { get; } = new BlockingCollection<string>(AsynchronousFileLogMessageSink.MaximumQueuedMessageCount);
        private Thread OutputThread { get; set; }

        private TextWriter TextWriter { get; }


        public AsynchronousFileLogMessageSink(
            TextWriter textWriter)
        {
            this.TextWriter = textWriter;

            this.OutputThread = new Thread(this.ProcessMessageQueue)
            {
                Name = "File logger queue proccessing thread",
                IsBackground = true,
            };
            this.OutputThread.Start();
        }

        public void Dispose()
        {
            this.LogMessageCollection.CompleteAdding();

            this.TextWriter.Dispose();

            GC.SuppressFinalize(this);
        }

        public void WriteLogMessage(string messageText)
        {
            // Adds a message to the queue rather than actually writing.

            // Check if the blocking collection is actually usable.
            if (!this.LogMessageCollection.IsAddingCompleted)
            {
                var added = this.LogMessageCollection.TryAdd(messageText);
                if (added)
                {
                    return;
                }
            }

            // If the blocking collection is unusable (the adding phase of its lifetime is completed, or it is full) then just spend the time to actually write the message.
            this.ActuallyWriteLogMessage(messageText);
        }

        private void ActuallyWriteLogMessage(string message)
        {
            this.TextWriter.WriteLine(message);
        }

        private void ProcessMessageQueue()
        {
            //try
            //{
            foreach (var message in this.LogMessageCollection.GetConsumingEnumerable())
            {
                this.ActuallyWriteLogMessage(message);
            }
            //}
        }
    }
}
