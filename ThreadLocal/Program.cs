using System;
using System.Threading;
namespace ThreadLocal
{
    public static class Program
    {
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });
        public static void Main()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() =>
                        {
                            for (int x = 0; x < _field.Value; x++)
                            {
                                Console.WriteLine("Thread B: {0}", x);
                            }
                        }).Start();
            Console.ReadKey();
        }
    }
}
