using System.Collections.Generic;
using System.Threading;
using ThreadingExplore.Core.DiningPhilosophers;
using ThreadingExplore.Core.SystemLog;

namespace ThreadingExplore.Console
{
    public class DiningPhilosophersRun
    {
        public void Run()
        {
            var fork0 = new PhilosopherFork("Fork 0");
            var fork1 = new PhilosopherFork("Fork 1");
            var fork2 = new PhilosopherFork("Fork 2");
            var fork3 = new PhilosopherFork("Fork 3");
            var fork4 = new PhilosopherFork("Fork 4");

            var consoleSystemLog = new ConsoleSystemLog();

            var phil0 = new Philosopher("Phil 0", 20, fork0, fork1, consoleSystemLog);
            var phil1 = new Philosopher("Phil 1", 20, fork1, fork2, consoleSystemLog);
            var phil2 = new Philosopher("Phil 2", 20, fork2, fork3, consoleSystemLog);
            var phil3 = new Philosopher("Phil 3", 20, fork3, fork4, consoleSystemLog);
            var phil4 = new Philosopher("Phil 4", 20, fork4, fork0, consoleSystemLog);

            var philosophers = new List<Philosopher>();

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