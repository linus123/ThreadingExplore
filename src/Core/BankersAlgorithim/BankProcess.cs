using System;
using System.Linq;
using System.Threading;

namespace ThreadingExplore.Core.BankersAlgorithim
{
    public class BankProcess
    {
        private readonly BankProcessResource[] _bankProcessResources;
        private readonly int _timeInMiliseconds;
        private readonly ManualResetEvent _resourcesSignal;

        public string ProcessName { get; }

        public BankProcess(
            string processName,
            int timeInMiliseconds,
            BankProcessResource[] bankProcessResources,
            ManualResetEvent resourcesSignal = null)
        {
            _resourcesSignal = resourcesSignal;
            _timeInMiliseconds = timeInMiliseconds;
            ProcessName = processName;
            _bankProcessResources = bankProcessResources;
        }

        public int GetResourceMaxAmount(
            ResourceName resourceName)
        {
            return _bankProcessResources.Single(r => r.Name == resourceName).MaxAmount;
        }

        public void Start(
            SystemResources system)
        {
            var wasSuccessful = system.ClaimResources(this);

            while (!wasSuccessful)
            {
                Console.WriteLine("Try again");

                if (_resourcesSignal != null)
                    _resourcesSignal.WaitOne();

                wasSuccessful = system.ClaimResources(this);
            }

            Thread.Sleep(_timeInMiliseconds);

            system.RestoreResources(this);

            if (_resourcesSignal != null)
            {
                _resourcesSignal.Set();
                _resourcesSignal.Reset();
            }
        }
    }
}