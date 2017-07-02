namespace ThreadingExplore.Core.SystemLog
{
    public class NoOpSystemLog : ISystemLog
    {
        public void Info(string message)
        {
        }
    }
}