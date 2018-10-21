using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ThreadingExplore.Console
{
    public class Program
    {
        public static int GetPrimesCount(int start, int count)
        {
            return ParallelEnumerable.Range(start, count).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }

        public static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
                ParallelEnumerable.Range(start, count).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

        public static void DisplayPrimeCounts()
        {
            for (int i = 0; i < 10; i++)
            {
                var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
                awaiter.OnCompleted(() => System.Console.WriteLine(awaiter.GetResult() + " primes between... "));
            }
            System.Console.WriteLine("Done");
        }

        static void Main(string[] args)
        {
            DisplayPrimeCounts();


//            var taskCompletionSource = new TaskCompletionSource<int>();
//
//            var timer = new System.Timers.Timer(5000)
//            {
//                AutoReset = false
//            };
//
//            timer.Elapsed += delegate(object sender, ElapsedEventArgs eventArgs)
//            {
//                timer.Dispose();
//                taskCompletionSource.SetResult(42);
//            };
//
//            timer.Start();
//
//            Task<int> task = taskCompletionSource.Task;
//            System.Console.WriteLine(task.Result);

            // **

            //            var banksAlgorithimRun = new BanksAlgorithmRun();
            //
            //            banksAlgorithimRun.Run();
            //
            //            System.Console.WriteLine("COMPLETE");
            //            System.Console.ReadLine();

            //            var manualResetEvent = new ManualResetEvent(false);
            //
            //            var thread1 = new Thread(() => {Work(manualResetEvent); });
            //            thread1.Start();
            //
            //            var thread2 = new Thread(() => { Work(manualResetEvent); });
            //            thread2.Start();
            //
            //            var thread3 = new Thread(() => { Work(manualResetEvent); });
            //            thread3.Start();
            //
            //            System.Console.WriteLine("Sleepting for 3 seconds.");
            //            Thread.Sleep(3000);
            //
            //            System.Console.WriteLine("Signaling.");
            //            manualResetEvent.Set();
            //            manualResetEvent.Reset();
            //
            //            thread1.Join();
            //            thread2.Join();
            //            thread3.Join();
            //
            //            System.Console.WriteLine("COMPLETE");
            //            System.Console.ReadLine();
            //        }
            //
            //        private static void Work(ManualResetEvent manualResetEvent)
            //        {
            //            System.Console.WriteLine("Wait One");
            //
            //            manualResetEvent.WaitOne();
            //
            //            System.Console.WriteLine("Thread Completed");
        }
    }
}
