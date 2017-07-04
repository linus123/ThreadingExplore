using System;
using System.Threading;

namespace ThreadingExplore.Core.DiningPhilosophers
{
    public class Philosopher
    {
        private readonly int _eatTimeInMiliSeconds;
        private readonly string _name;

        private readonly Butler _butler;
        private readonly int _placeNumber;
        private readonly SimulationLog _simulationLog;

        public Philosopher(
            string name,
            int eatTimeInMiliSeconds,
            Butler butler,
            int placeNumber,
            SimulationLog simulationLog)
        {
            _simulationLog = simulationLog;
            _placeNumber = placeNumber;
            _butler = butler;
            _name = name;
            _eatTimeInMiliSeconds = eatTimeInMiliSeconds;
        }

        public void StartEating()
        {
            var eatRequestResult = _butler.TryToEatAtPlace(_placeNumber);

            while (!eatRequestResult.CanEat)
            {
                _simulationLog.Info($"{_name} cannot eat {eatRequestResult.Message}.");

                Thread.Sleep(10);

                eatRequestResult = _butler.TryToEatAtPlace(_placeNumber);
            }

            _simulationLog.Info($"{_name} is now eating for {_eatTimeInMiliSeconds} milli seconds.");
            Thread.Sleep(_eatTimeInMiliSeconds);
            _simulationLog.Info($"{_name} has completed eating.");

            _butler.PutDownForks(_placeNumber);
        }

//        private void ThinkWithPossibliltyOfStarving(
//            int milliSeconds)
//        {
//            if (_totalThinkTime + milliSeconds > _starveThreashhold)
//                throw new Exception($"{_name} has starved.");
//
//            Thread.Sleep(milliSeconds);
//
//            _totalThinkTime += milliSeconds;
//        }
    }
}