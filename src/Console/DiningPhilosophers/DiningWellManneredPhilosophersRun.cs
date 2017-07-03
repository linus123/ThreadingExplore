using System.Collections.Generic;
using System.Threading;
using ThreadingExplore.Core.DiningPhilosophers;
using ThreadingExplore.Core.SystemLog;

namespace ThreadingExplore.Console.DiningPhilosophers
{
    public class DiningWellManneredPhilosophersRun
    {
        public void Run()
        {
            var fork0 = new PhilosopherFork("Fork 0");
            var fork1 = new PhilosopherFork("Fork 1");
            var fork2 = new PhilosopherFork("Fork 2");
            var fork3 = new PhilosopherFork("Fork 3");
            var fork4 = new PhilosopherFork("Fork 4");

            var consoleSystemLog = new ConsoleSystemLog();

            var starveThreashhold = 30;

            var phil0 = new WellManneredPhilosopher("Phil 0", 100, fork0, fork1, starveThreashhold, consoleSystemLog);
            var phil1 = new WellManneredPhilosopher("Phil 1", 100, fork1, fork2, starveThreashhold, consoleSystemLog);
            var phil2 = new WellManneredPhilosopher("Phil 2", 100, fork2, fork3, starveThreashhold, consoleSystemLog);
            var phil3 = new WellManneredPhilosopher("Phil 3", 100, fork3, fork4, starveThreashhold, consoleSystemLog);
            var phil4 = new WellManneredPhilosopher("Phil 4", 100, fork4, fork0, starveThreashhold, consoleSystemLog);

            var philosophers = new List<WellManneredPhilosopher>();

            philosophers.Add(phil0);
            philosophers.Add(phil1);
            philosophers.Add(phil2);
            philosophers.Add(phil3);
            philosophers.Add(phil4);

            var threads = new List<Thread>();

            foreach (var philosopher in philosophers)
            {
                var thread = new Thread(() => philosopher.StartEating());
                thread.Start();

                threads.Add(thread);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }
}