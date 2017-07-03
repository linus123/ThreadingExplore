using System;
using System.Diagnostics;
using System.Threading;
using ThreadingExplore.Core.SystemLog;

namespace ThreadingExplore.Core.DiningPhilosophers
{
    public class WellManneredPhilosopher
    {
        private readonly PhilosopherFork _rightFork;
        private readonly PhilosopherFork _leftFork;

        private readonly int _eatTimeInMiliSeconds;
        private readonly string _name;

        private readonly ISystemLog _systemLog;
        private readonly int _starveThreashhold;

        public WellManneredPhilosopher(
            string name,
            int eatTimeInMiliSeconds,
            PhilosopherFork rightFork,
            PhilosopherFork leftFork,
            int starveThreashhold,
            ISystemLog systemLog)
        {
            _starveThreashhold = starveThreashhold;
            _systemLog = systemLog;
            _name = name;
            _eatTimeInMiliSeconds = eatTimeInMiliSeconds;
            _rightFork = rightFork;
            _leftFork = leftFork;
        }

        public void StartEating()
        {
            var stopwatch = Stopwatch.StartNew();

            var hasLeftFork = _leftFork.TryToPickup();
            var hasRightFork = _rightFork.TryToPickup();

            while (!hasLeftFork.WasPickedUp || !hasRightFork.WasPickedUp)
            {
                _leftFork.Release();
                _rightFork.Release();

                _systemLog.Info(stopwatch, $"{_name} cannot pickup a fork. Yielding.");
                _systemLog.Info(stopwatch, hasLeftFork.State);
                _systemLog.Info(stopwatch, hasRightFork.State);
                YieldWithPossibliltyOfStarving(stopwatch);

                hasLeftFork = _leftFork.TryToPickup();
                hasRightFork = _rightFork.TryToPickup();
            }

            _systemLog.Info(stopwatch, $"{_name} is now eating for {_eatTimeInMiliSeconds} milli seconds.");
            Thread.Sleep(_eatTimeInMiliSeconds);

            _leftFork.Release();
            _rightFork.Release();

            _systemLog.Info(stopwatch, $"Total run time {stopwatch.ElapsedMilliseconds}.");
        }

        private void YieldWithPossibliltyOfStarving(
            Stopwatch stopwatch)
        {
            var stopwatchElapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            _systemLog.Info(stopwatch, $"Diff {stopwatchElapsedMilliseconds}.");

            if (stopwatchElapsedMilliseconds > _starveThreashhold)
                throw new Exception($"{_name} has starved.");

            Thread.Yield();
        }
    }
}