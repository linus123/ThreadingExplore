using System.Collections.Generic;
using System.Threading;
using ThreadingExplore.Core;
using ThreadingExplore.Core.DiningPhilosophers;

namespace ThreadingExplore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var philosopherTable = new PhilosopherTable(5);

            var simulationLog = new SimulationLog();

            var philosopher0 = new Philosopher("P0", 300, philosopherTable, 0, simulationLog);
            var philosopher1 = new Philosopher("P1", 1000, philosopherTable, 1, simulationLog);
            var philosopher2 = new Philosopher("P2", 10, philosopherTable, 2, simulationLog);
            var philosopher3 = new Philosopher("P3", 30, philosopherTable, 3, simulationLog);
            var philosopher4 = new Philosopher("P4", 10, philosopherTable, 4, simulationLog);

            var philosophers = new List<Philosopher>();
            philosophers.Add(philosopher0);
            philosophers.Add(philosopher1);
            philosophers.Add(philosopher2);
            philosophers.Add(philosopher3);
            philosophers.Add(philosopher4);

            var threads = new List<Thread>();

            simulationLog.StartSimulation();

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
