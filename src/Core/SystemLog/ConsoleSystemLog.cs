using System;
using System.Threading;

namespace ThreadingExplore.Core.SystemLog
{
    public class ConsoleSystemLog : ISystemLog
    {
        public void Info(string message)
        {
            var dateTime = DateTime.Now;

            Console.WriteLine("{0} {1} T:{2} - {3}",
                dateTime.ToShortDateString(),
                dateTime.ToLongTimeString(),
                Thread.CurrentThread.ManagedThreadId,
                message);
        }
    }
}