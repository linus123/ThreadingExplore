namespace ThreadingExplore.Core.DiningPhilosophers
{
    public class PhilosopherFork
    {
        private readonly object _lockObject = new object();

        private bool _isInUse;

        public PhilosopherFork(
            string forkName)
        {
            ForkName = forkName;

            _isInUse = false;
        }

        public string ForkName { get; }

        public PickupStatus TryToPickup()
        {
            lock (_lockObject)
            {
                if (_isInUse)
                {
                    return new PickupStatus(false, string.Format($"{ForkName} was NOT picked up."));
                }

                _isInUse = true;
                return new PickupStatus(true, string.Format($"{ForkName} was picked up."));
            }

        }

        public void Release()
        {
            lock (_lockObject)
            {
                _isInUse = false;
            }
        }

        public class PickupStatus
        {
            public bool WasPickedUp { get; }
            public string State { get; }

            public PickupStatus(
                bool wasPickedUp,
                string state)
            {
                State = state;
                WasPickedUp = wasPickedUp;
            }
        }

    }
}