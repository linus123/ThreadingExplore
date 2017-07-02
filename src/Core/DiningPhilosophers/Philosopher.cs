using System.Threading;
using ThreadingExplore.Core.SystemLog;

namespace ThreadingExplore.Core.DiningPhilosophers
{
    public class Philosopher
    {
        private PhilosopherFork _rightFork;
        private PhilosopherFork _leftFork;

        private readonly int _eatTimeInMiliSeconds;
        private readonly string _name;

        private readonly ISystemLog _systemLog;

        public Philosopher(
            string name,
            int eatTimeInMiliSeconds,
            PhilosopherFork rightFork,
            PhilosopherFork leftFork,
            ISystemLog systemLog)
        {
            _systemLog = systemLog;
            _name = name;
            _eatTimeInMiliSeconds = eatTimeInMiliSeconds;
            _rightFork = rightFork;
            _leftFork = leftFork;
        }

        public void StartEating()
        {
            var hasLeftFork = _leftFork.TryToPickup();

            while (!hasLeftFork)
            {
                _systemLog.Info($"{_name} cannot pickup left fork. Thinking for 10 milli seconds.");
                Thread.Sleep(10);

                hasLeftFork = _leftFork.TryToPickup();
            }

            var hasRightFork = _rightFork.TryToPickup();

            while (!hasRightFork)
            {
                _systemLog.Info($"{_name} cannot pickup right fork. Thinking for 10 milli seconds.");
                Thread.Sleep(10);

                hasRightFork = _rightFork.TryToPickup();
            }

            _systemLog.Info($"{_name} is now eating for {_eatTimeInMiliSeconds} milli seconds.");
            Thread.Sleep(_eatTimeInMiliSeconds);

            _leftFork.Release();
            _rightFork.Release();
        }
    }
}