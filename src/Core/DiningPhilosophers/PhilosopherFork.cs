using System.Threading;

namespace ThreadingExplore.Core.DiningPhilosophers
{
    public class PhilosopherFork
    {
        private readonly Semaphore _semaphore;

        public PhilosopherFork(
            string forkName)
        {
            ForkName = forkName;
            _semaphore = new Semaphore(1, 1);
        }

        public string ForkName { get; }

        public bool TryToPickup()
        {
            return _semaphore.WaitOne(0);
        }

        public void Release()
        {
            _semaphore.Release();
        }
    }
}