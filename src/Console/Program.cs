using System.Collections.Generic;
using System.Threading;
using ThreadingExplore.Core.BankersAlgorithim;
using ThreadingExplore.Core.SystemLog;

namespace ThreadingExplore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var banksAlgorithimRun = new BanksAlgorithimRun();

            banksAlgorithimRun.Run();

            System.Console.WriteLine("COMPLETED");

            System.Console.ReadLine();
        }
    }
}
