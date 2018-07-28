using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadingExplore.Core.SystemLog
{
    public class ConsoleSystemLog : ISystemLog
    {
        private readonly Stopwatch _stopwatch;

        public ConsoleSystemLog(
            Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public void Info(
            string message)
        {
            Console.WriteLine("{0} T:{1} - {2}",
                _stopwatch.ElapsedMilliseconds,
                Thread.CurrentThread.ManagedThreadId,
                message);
        }
    }
}