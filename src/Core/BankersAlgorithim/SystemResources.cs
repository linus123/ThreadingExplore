using System.Linq;
using ThreadingExplore.Core.SystemLog;

namespace ThreadingExplore.Core.BankersAlgorithim
{
    public class SystemResources
    {
        private readonly SystemResource[] _systemResources;
        private readonly ISystemLog _systemLog;

        private readonly object _lockObject = new object();

        public SystemResources(
            SystemResource[] systemResources,
            ISystemLog systemLog)
        {
            _systemLog = systemLog;
            _systemResources = systemResources;

            _systemLog.Info("Created System Resources");
            _systemLog.Info(GetSystemSummary());
        }

        public bool ClaimResources(
            Process process)
        {
            lock (_lockObject)
            {
                foreach (var systemResource in _systemResources)
                {
                    var resourceMaxAmount = process.GetResourceMaxAmount(systemResource.Name);

                    if (resourceMaxAmount > systemResource.CurrentAmount)
                    {
                        _systemLog.Info(string.Format("Not enought resources for {0}", process.ProcessName));
                        _systemLog.Info(GetSystemSummary());
                        return false;
                    }
                }

                foreach (var systemResource in _systemResources)
                {
                    var resourceMaxAmount = process.GetResourceMaxAmount(systemResource.Name);

                    systemResource.ClaimResourceCount(resourceMaxAmount);

                }

                _systemLog.Info(string.Format("Claimed Resources for {0}", process.ProcessName));
                _systemLog.Info(GetSystemSummary());

                return true;
            }
        }

        public void RestoreResources(
            Process process)
        {
            lock (_lockObject)
            {
                foreach (var systemResource in _systemResources)
                {
                    var resourceMaxAmount = process.GetResourceMaxAmount(systemResource.Name);

                    systemResource.RestoreResourceCount(resourceMaxAmount);

                }

                _systemLog.Info(string.Format("Restored Resources for {0}", process.ProcessName));
                _systemLog.Info(GetSystemSummary());
            }
        }

        public string GetSystemSummary()
        {
            return _systemResources
                .Select(r => r.GetSummary())
                .Aggregate((f, s) => string.Format("{0} | {1}", f, s));
        }
    }
}