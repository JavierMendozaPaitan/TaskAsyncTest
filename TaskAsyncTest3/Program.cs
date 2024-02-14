using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncTest3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task taskA = Task.Run(() => Thread.Sleep(3000));

            Console.WriteLine("taskA Status [1]: {0}", taskA.Status);

            try
            {
                Console.WriteLine("Waiting for task to complete");
                taskA.Wait();
                Console.WriteLine("taskA Status [2]: {0}", taskA.Status);

            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskA.");
            }

            Console.WriteLine("Press Enter to continue:");
            Console.ReadLine();

            //###################################
            Console.WriteLine("Task duration: 5 seconds");
            Task taskB = Task.Run(() => Thread.Sleep(5000));
            Console.WriteLine($"TaskB status: [{taskB.Status}]");
            try
            {
                Console.WriteLine("Waiting for 1 second");
                taskB.Wait(1000);       // Wait for 1 second.

                bool completed = taskB.IsCompleted;
                Console.WriteLine("Task B completed: {0}, Status: {1}",
                                 completed, taskB.Status);

                if (!completed)
                    Console.WriteLine("Timed out before task B completed.");
            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskB.");
            }

            Console.ReadKey();

        }
    }
}
