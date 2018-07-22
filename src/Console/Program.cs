using System.Diagnostics;
using System.Threading;
using ThreadingExplore.Core.TicTacToe;

namespace ThreadingExplore.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var board = new TicTacToeBoard();
            string[] stringBoard;
            WinStatus winStatus;

            var playerO = new Player(TicTacToeCellValue.O);
            var playerX = new Player(TicTacToeCellValue.X);

            while (true)
            {
                System.Console.WriteLine("O Move");
                playerO.MakeNextMove(board);
                stringBoard = board.GetStringBoard();
                PrintBoard(stringBoard);

                winStatus = WinDetector.GetWinStatus(board);

                if (winStatus.IsWon)
                {
                    System.Console.WriteLine(winStatus.WinMessage);
                    break;
                }

                if (TieDetector.IsTied(board))
                {
                    System.Console.WriteLine("Tied");
                    break;
                }

                System.Console.WriteLine("X Move");
                playerX.MakeNextMove(board);
                stringBoard = board.GetStringBoard();
                PrintBoard(stringBoard);

                winStatus = WinDetector.GetWinStatus(board);

                if (winStatus.IsWon)
                {
                    System.Console.WriteLine(winStatus.WinMessage);
                    break;
                }

                if (TieDetector.IsTied(board))
                {
                    System.Console.WriteLine("Tied");
                    break;
                }
            }


            System.Console.ReadLine();
        }

        private static void PrintBoard(string[] stringBoard)
        {
            foreach (var s in stringBoard)
            {
                System.Console.WriteLine(s);
            }

            System.Console.WriteLine();
        }

//        public static void Main(string[] args)
//        {
//            var signal = new ManualResetEvent(false);
//            var stopwatch = new Stopwatch();
//            stopwatch.Start();
//
//            var thread1 = new Thread(() =>
//            {
//                System.Console.WriteLine($"{stopwatch.ElapsedMilliseconds}: Thread1: Waiting for signal...");
//                signal.WaitOne();
//                System.Console.WriteLine($"{stopwatch.ElapsedMilliseconds}: Thread1: Got signal.");
//            });
//
//            var thread2 = new Thread(() =>
//            {
//                System.Console.WriteLine($"{stopwatch.ElapsedMilliseconds}: Thread2: Sleeping");
//                Thread.Sleep(3000);
//                System.Console.WriteLine($"{stopwatch.ElapsedMilliseconds}: Thread2: Waiting for signal...");
//                signal.WaitOne();
//                System.Console.WriteLine($"{stopwatch.ElapsedMilliseconds}: Thread2: Got signal.");
//            });
//
//            thread2.Start();
//            thread1.Start();
//
//            Thread.Sleep(2000);
//            signal.Set();
//
//            thread1.Join();
//            thread2.Join();
//            signal.Dispose();
//
//            System.Console.WriteLine($"{stopwatch.ElapsedMilliseconds}: Done");
//            stopwatch.Stop();
//            System.Console.ReadLine();
//        }

        //        static void Main(string[] args)
        //        {
        //            bool done = false;
        //
        //            ThreadStart action = () =>
        //            {
        //                if (!done)
        //                {
        //                    done = true;
        //                    System.Console.WriteLine("Done");
        //                }
        //            };
        //
        //            new Thread(action).Start();
        //            action();
        //
        //            System.Console.ReadLine();
        //        }


        //        static void Main(string[] args)
        //        {
        //            var yThread = new Thread(WriteY);
        //
        //            yThread.Start();
        //            yThread.Name = "y thread";
        //
        //            if (yThread.IsAlive)
        //            {
        //                System.Console.Write("'Thread y alive'");
        //
        //            }
        //
        //            for (int i = 0; i < 1000; i++)
        //            {
        //                System.Console.Write("x");
        //            }
        //
        //            System.Console.ReadLine();
        //        }
        //
        //        static void WriteY()
        //        {
        //            for (int i = 0; i < 1000; i++)
        //            {
        //                System.Console.Write("y");
        //            }
        //        }
    }
}
