using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadingExplore.Core
{
    public class SimulationLog
    {
        private readonly Stopwatch _stopwatch;

        public SimulationLog()
        {
            _stopwatch = new Stopwatch();
        }

        public void StartSimulation()
        {
            _stopwatch.Start();
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