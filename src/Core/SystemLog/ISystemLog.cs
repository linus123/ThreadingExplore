using System.Diagnostics;

namespace ThreadingExplore.Core.SystemLog
{
    public interface ISystemLog
    {
        void Info(string message);
        void Info(Stopwatch stopwatch, string message);
    }
}