using System;
using System.Linq;
using System.Threading;

namespace ThreadingExplore.Core.BankersAlgorithim
{
    public class Process
    {
        private readonly ProcessResource[] _processResources;
        private int _timeInMiliseconds;
        public string ProcessName { get; }

        public Process(
            string processName,
            int timeInMiliseconds,
            ProcessResource[] processResources)
        {
            _timeInMiliseconds = timeInMiliseconds;
            ProcessName = processName;
            _processResources = processResources;
        }

        public int GetResourceMaxAmount(
            ResourceName resourceName)
        {
            return _processResources.Single(r => r.Name == resourceName).MaxAmount;
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