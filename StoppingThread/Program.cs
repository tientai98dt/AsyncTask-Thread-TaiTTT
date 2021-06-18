using System;
using System.Threading;
namespace StoppingThread
{
    class Program
    {
        private static ManualResetEvent resetEvent1 = new ManualResetEvent(false);
        private static ManualResetEvent resetEvent2 = new ManualResetEvent(false);
        private static bool run1 = true;
        private static bool run2 = true;
        static void Main(string[] args)
        {
            ThreadStart threadStart1 = new ThreadStart(Thread1Work);
            ThreadStart threadStart2 = new ThreadStart(Thread2Work);

            Thread t1 = new Thread(threadStart1);
            Thread t2 = new Thread(threadStart2);

            Console.WriteLine("press Key to start thread");
            Console.WriteLine("Press return again to stop thread");

            string a = Console.ReadLine();
            if (a.Equals("1"))
            {
                t1.Start();
            }

            else if (a.Equals("2"))
            {
                t2.Start();
            }

            else
            {
                t1.Start();
                t2.Start();
            }

            string b = Console.ReadLine();
            if (b.Equals("1"))
            {
                run1 = false;
            }

            if (b.Equals("2"))
            {
                run2 = false;
            }

            else
            {
                run1 = false;
                run2 = false;
            }
            Console.ReadLine();
        }


        private static void Thread1Work()
        {
            Random rand = new Random();
            while (run1)
            {
                Console.WriteLine("Worked for thread 1");
                Thread.Sleep(rand.Next(100, 2000));
            }
            resetEvent1.Set();
        }
        private static void Thread2Work()
        {
            Random rand = new Random();
            while (run2)
            {
                Console.WriteLine("Worked for thread 2");
                Thread.Sleep(rand.Next(100, 2000));
            }
            resetEvent2.Set();
        }
    }
}
