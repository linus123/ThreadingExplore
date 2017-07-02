﻿using System;
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
        private int _totalThinkTime;
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

            _totalThinkTime = 0;
        }

        public void StartEating()
        {
            var hasLeftFork = _leftFork.TryToPickup();
            var hasRightFork = _rightFork.TryToPickup();

            while (!hasLeftFork || !hasRightFork)
            {
                _leftFork.Release();
                _rightFork.Release();

                _systemLog.Info($"{_name} cannot pickup a fork. Thinking for 10 milli seconds.");
                ThinkWithPossibliltyOfStarving(10);

                hasLeftFork = _leftFork.TryToPickup();
                hasRightFork = _rightFork.TryToPickup();
            }

            _systemLog.Info($"{_name} is now eating for {_eatTimeInMiliSeconds} milli seconds.");
            Thread.Sleep(_eatTimeInMiliSeconds);

            _leftFork.Release();
            _rightFork.Release();
        }

        private void ThinkWithPossibliltyOfStarving(
            int milliSeconds)
        {
            if (_totalThinkTime + milliSeconds > _starveThreashhold)
                throw new Exception($"{_name} has starved.");

            Thread.Sleep(milliSeconds);

            _totalThinkTime += milliSeconds;
        }
    }
}