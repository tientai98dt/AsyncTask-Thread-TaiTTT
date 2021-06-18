using System;
using System.Threading;
namespace ThreadStaticAttibute
{
    public static class Program
    {
        [ThreadStatic]
        public static int _field;
        public static void Main()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                    Thread.Sleep(500);
                }
            }).Start();
            
            new Thread(() =>
                        {
                            for (int x = 0; x < 10; x++)
                            {
                                _field++;
                                Console.WriteLine("Thread B: {0}", _field);
                                Thread.Sleep(500);
                            }
                        }).Start();

            Console.ReadKey();
        }
    }

}
