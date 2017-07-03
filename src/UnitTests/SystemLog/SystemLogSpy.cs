using System.Collections.Generic;
using System.Diagnostics;
using ThreadingExplore.Core.SystemLog;

namespace ThreadingExplore.UnitTests.SystemLog
{
    public class SystemLogSpy : ISystemLog
    {
        private readonly List<string> _messages;

        public SystemLogSpy()
        {
            _messages = new List<string>();
        }

        public void Info(string message)
        {
            _messages.Add(message);
        }

        public void Info(Stopwatch stopwatch, string message)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetAllMessages()
        {
            return _messages.ToArray();
        }
    }
}