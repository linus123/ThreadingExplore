using System;
using System.Threading;

namespace ThreadingExplore.Core.DiningPhilosophers
{
    public class Philosopher
    {
        private readonly int _eatTimeInMiliSeconds;
        private readonly string _name;

        private readonly PhilosopherTable _philosopherTable;
        private readonly int _placeNumber;
        private readonly SimulationLog _simulationLog;

        public Philosopher(
            string name,
            int eatTimeInMiliSeconds,
            PhilosopherTable philosopherTable,
            int placeNumber,
            SimulationLog simulationLog)
        {
            _simulationLog = simulationLog;
            _placeNumber = placeNumber;
            _philosopherTable = philosopherTable;
            _name = name;
            _eatTimeInMiliSeconds = eatTimeInMiliSeconds;
        }

        public void StartEating()
        {
            var eatRequestResult = _philosopherTable.TryToEatAtPlace(_placeNumber);

            while (!eatRequestResult.CanEat)
            {
                Thread.Yield();

                eatRequestResult = _philosopherTable.TryToEatAtPlace(_placeNumber);
            }

            _simulationLog.Info($"{_name} is now eating for {_eatTimeInMiliSeconds} milli seconds.");
            Thread.Sleep(_eatTimeInMiliSeconds);
            _simulationLog.Info($"{_name} has completed eating.");

            _philosopherTable.PutDownForks(_placeNumber);
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