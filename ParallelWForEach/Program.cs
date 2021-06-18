using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelWForEach
{
    class Program
    {
        public static void PintInfo(string info) =>
        Console.WriteLine($"{info,10}    task:{Task.CurrentId,3}    " +
                          $"thread: {Thread.CurrentThread.ManagedThreadId}");
        public static async void RunTask(string s)
        {
            PintInfo($"Start {s,10}");
            await Task.Delay(1);                 // Task.Delay là một async nên có thể await, RunTask chuyển điểm gọi nó tại đây
            PintInfo($"Finish {s,10}");
        }

        public static void ParallelFor()
        {

            string[] source = new string[] {"1","2","3",
                                    "4","5","6",
                                    "7","8","9"};
            // Dùng List thì khởi tạo
            // List<string> source = new List<string>();
            // source.Add("xuanthulab1");

            ParallelLoopResult result = Parallel.ForEach(
                source, RunTask
            );

            Console.WriteLine($"All task started: {result.IsCompleted}");
        }
        static void Main(string[] args)
        {
            ParallelFor();
            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}
