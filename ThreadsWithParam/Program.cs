using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsWithParam
{
    public static class Program
    {
        public static void ThreadMethod(object name)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Thread say hello to " + name.ToString());
        }
        public static void Main()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start("Linh Pro vl");
            Console.ReadKey();
        }
    }
}
