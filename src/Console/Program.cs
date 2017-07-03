using ThreadingExplore.Console.DiningPhilosophers;

namespace ThreadingExplore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var actionRun = new DiningWellManneredPhilosophersRun();

            actionRun.Run();
        }
    }
}
