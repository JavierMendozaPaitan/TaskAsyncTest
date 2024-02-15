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
            Action<object> actionForTask = MethodForTask1;
            Task taskC = Task.Factory.StartNew(actionForTask, "name");
            Task taskA = Task.Factory.StartNew(()=> Thread.Sleep(5000));

            Console.WriteLine("taskA Status [1]: {0}", taskA.Status);
            Console.WriteLine("taskC Status [1]: {0}", taskC.Status);

            try
            {
                Console.WriteLine("Waiting for task to complete");
                taskA.Wait();
                taskC.Wait();
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
                Thread.Sleep(6000);
                Console.WriteLine($"task status: [{taskB.Status}]");

            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskB.");
            }

            Console.ReadKey();

        }

        private static void MethodForTask1(object name)
        {
            Console.WriteLine($"Task parameter is {name}");
            Thread.Sleep(3000);
        }
    }
}
