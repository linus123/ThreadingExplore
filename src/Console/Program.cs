namespace ThreadingExplore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var actionRun = new DiningPhilosophersRun();

            actionRun.Run();
        }
    }
}
