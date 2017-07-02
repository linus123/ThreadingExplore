using System.Collections.Generic;
using System.Threading;
using ThreadingExplore.Core.BankersAlgorithim;
using ThreadingExplore.Core.SystemLog;

namespace ThreadingExplore.Console
{
    public class BanksAlgorithimRun
    {
        public void Run()
        {
            var systemResources = new[]
            {
                new SystemResource(ResourceName.A, 10),
                new SystemResource(ResourceName.B, 10),
                new SystemResource(ResourceName.C, 10),
                new SystemResource(ResourceName.D, 10),
            };

            var system = new SystemResources(systemResources, new ConsoleSystemLog());

            // **

            var processes = new List<BankProcess>();

            var process1 = new BankProcess("P1", 5, new[]
            {
                new BankProcessResource(ResourceName.A, 5),
                new BankProcessResource(ResourceName.B, 5),
                new BankProcessResource(ResourceName.C, 6),
                new BankProcessResource(ResourceName.D, 5),
            });

            processes.Add(process1);

            var process2 = new BankProcess("P2", 10, new[]
            {
                new BankProcessResource(ResourceName.A, 7),
                new BankProcessResource(ResourceName.B, 1),
                new BankProcessResource(ResourceName.C, 3),
                new BankProcessResource(ResourceName.D, 9),
            });

            processes.Add(process2);

            var process3 = new BankProcess("P3", 300, new[]
            {
                new BankProcessResource(ResourceName.A, 1),
                new BankProcessResource(ResourceName.B, 1),
                new BankProcessResource(ResourceName.C, 1),
                new BankProcessResource(ResourceName.D, 1),
            });

            processes.Add(process3);

            var threads = new List<Thread>();

            foreach (var process in processes)
            {
                var thread = new Thread(() => process.Start(system));
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