using System;
using ThreadingExplore.Core.BplusTreeDataStructure;

namespace ThreadingExplore.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();


            var bplusTree = new BplusTree(4);

            for (int i = 0; i < 1000000; i++)
            {
                var num = random.Next(1, 1000000);

                bplusTree.Insert(new CustomerRecord(num, "Customer {num}"));
            }

            //var stringVersion = bplusTree.GetStringVersion();

            //System.Console.WriteLine(stringVersion);
        }
    }
}
