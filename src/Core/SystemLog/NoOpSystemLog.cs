using System.Diagnostics;

namespace ThreadingExplore.Core.SystemLog
{
    public class NoOpSystemLog : ISystemLog
    {
        public void Info(string message)
        {
        }

        public void Info(Stopwatch stopwatch, string message)
        {
        }
    }
}