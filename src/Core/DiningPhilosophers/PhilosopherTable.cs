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
            var leftForkNumber = seatNumber;
            var rightForNumber = GetRightForkNumber(seatNumber);

            if (!_forkArray[leftForkNumber] && !_forkArray[rightForNumber])
            {
                _forkArray[leftForkNumber] = true;
                _forkArray[rightForNumber] = true;
                return new EatRequestResult(true, "Eat");
            }

            return new EatRequestResult(false, "Do not eat");

        }

        private int GetRightForkNumber(
            int seatNumber)
        {
            if (seatNumber == _forkArray.Length - 1)
                return 0;

            return seatNumber + 1;
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