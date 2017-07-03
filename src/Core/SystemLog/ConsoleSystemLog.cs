using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadingExplore.Core.SystemLog
{
    public class ConsoleSystemLog : ISystemLog
    {
        public void Info(
            Stopwatch stopwatch,
            string message)
        {
            Console.WriteLine("{0} T:{1} - {2}",
                stopwatch.ElapsedMilliseconds,
                Thread.CurrentThread.ManagedThreadId,
                message);
        }

        public void Info(
            string message)
        {
            Console.WriteLine("XX T:{0} - {1}",
                Thread.CurrentThread.ManagedThreadId,
                message);
        }
    }
}