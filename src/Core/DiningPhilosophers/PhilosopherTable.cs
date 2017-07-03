namespace ThreadingExplore.Core.DiningPhilosophers
{
    public class PhilosopherTable
    {
        private readonly bool[] _forkArray;

        public PhilosopherTable(
            int forkCount)
        {
            _forkArray = new bool[forkCount];

            for (int i = 0; i < forkCount; i++)
            {
                _forkArray[0] = false;
            }
        }

        public EatRequestResult TryToEatAtPlace(
            int seatNumber)
        {
            return new EatRequestResult(true, "Eat");
        }

        private int GetRightForkNumber(
            int forkNumber)
        {
            if (forkNumber == _forkArray.Length - 1)
                return 0;

            return forkNumber + 1;
        }

        public class EatRequestResult
        {
            public EatRequestResult(
                bool canEat,
                string message)
            {
                Message = message;
                CanEat = canEat;
            }

            public bool CanEat { get; }
            public string Message { get; }
        }
    }
}