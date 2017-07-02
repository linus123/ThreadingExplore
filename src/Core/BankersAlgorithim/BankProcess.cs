using System;
using System.Linq;
using System.Threading;

namespace ThreadingExplore.Core.BankersAlgorithim
{
    public class BankProcess
    {
        private readonly BankProcessResource[] _bankProcessResources;
        private readonly int _timeInMiliseconds;
        public string ProcessName { get; }

        public BankProcess(
            string processName,
            int timeInMiliseconds,
            BankProcessResource[] bankProcessResources)
        {
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

                wasSuccessful = system.ClaimResources(this);
            }

            Thread.Sleep(_timeInMiliseconds);

            system.RestoreResources(this);
        }
    }
}