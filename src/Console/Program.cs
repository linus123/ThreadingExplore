using System.Threading;

namespace ThreadingExplore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(WriteY);

            thread.Start();

            for (int i = 0; i < 1000; i++)
            {
                System.Console.Write("x");
            }

            System.Console.ReadLine();
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                System.Console.Write("y");
            }
        }
    }
}
