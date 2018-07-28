using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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

            var stopwatch = new Stopwatch();

            var consoleSystemLog = new ConsoleSystemLog(
                stopwatch);

            var system = new SystemResources(systemResources, consoleSystemLog);

            // **

            var processes = new List<BankProcess>();

            var resourcesSignal = new ManualResetEvent(false);

            var process1 = new BankProcess("P1", 500, new[]
            {
                new BankProcessResource(ResourceName.A, 5),
                new BankProcessResource(ResourceName.B, 5),
                new BankProcessResource(ResourceName.C, 6),
                new BankProcessResource(ResourceName.D, 5),
            },
                resourcesSignal);

            processes.Add(process1);

            var process2 = new BankProcess("P2", 10, new[]
            {
                new BankProcessResource(ResourceName.A, 7),
                new BankProcessResource(ResourceName.B, 1),
                new BankProcessResource(ResourceName.C, 3),
                new BankProcessResource(ResourceName.D, 9),
            },
                resourcesSignal);

            processes.Add(process2);

            var process3 = new BankProcess("P3", 300, new[]
            {
                new BankProcessResource(ResourceName.A, 1),
                new BankProcessResource(ResourceName.B, 1),
                new BankProcessResource(ResourceName.C, 1),
                new BankProcessResource(ResourceName.D, 1),
            },
                resourcesSignal);

            processes.Add(process3);

            var tasks = new List<Task>();

            stopwatch.Start();

            foreach (var process in processes)
            {
                var task = Task.Run(() => { process.Start(system); });

                tasks.Add(task);
            }

            foreach (var task in tasks)
            {
                task.Wait();
            }

            stopwatch.Stop();

        }
    }
}