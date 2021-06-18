using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taskdemo3
{
    class Program
    {
        public static async Task Main()
        {
            var random = new Random();
            IEnumerable<Task<int>> tasks = Enumerable.Range(1, 5).Select(n => Task.Run(() =>
            {
                Console.WriteLine("I'm task " + n);
                return n;
            }));

            Task<int[]> task = Task.WhenAll(tasks);
            int[] results = await task;

            Console.WriteLine(string.Join(",", results.Select(n => n.ToString())));
            Console.ReadLine();
        }
    }
}
