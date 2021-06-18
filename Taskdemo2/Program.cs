using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Taskdemo2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 1 finished");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1500);
                Console.WriteLine("Task 2 finished");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task 3 finished");
                return 3;
            }
            );
            Task.WaitAll(tasks);
            Console.ReadLine();
        }
    }
}