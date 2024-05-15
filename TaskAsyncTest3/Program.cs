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
            Action<object> actionToExecute = MethodToExecute;

            Console.WriteLine("Creating Task A");
            Task taskA = Task.Factory.StartNew(actionToExecute, "A");

            try
            {
                Console.WriteLine("Waiting for 2 second");
                taskA.Wait(2000);       // Wait for 1 second.
                Console.WriteLine("\nChecking if Task A is completed");
                Console.WriteLine($"\tTask A is completed: [{taskA.IsCompleted}]\n" +
                    $"\tStatus:[{taskA.Status}]");

                if (!taskA.IsCompleted)
                    Console.WriteLine("...Timed out!");
                Console.WriteLine("Waiting up to the task end");
                taskA.Wait();
                Console.WriteLine($"\tTask A is completed: [{taskA.IsCompleted}]\n" +
                    $"\tStatus:[{taskA.Status}]");



                Console.ReadLine();

                Console.WriteLine("Creating Task B");
                Task taskB = Task.Factory.StartNew(actionToExecute, "B");

                int i = 0;
                while(!taskB.IsCompleted)
                {
                    Console.Write($"Task B Status: [{taskB.Status}][{++i}]\r");
                    taskB.Wait(500);
                }

                Console.WriteLine($"\n\tTask B is completed: [{taskB.IsCompleted}]\n" +
                    $"\tStatus:[{taskB.Status}]");

            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskB.");
            }

            Console.ReadLine();

        }

        private static void MethodToExecute(object name)
        {
            Console.WriteLine($"---> Task action [{name}] is starting");
            Thread.Sleep(7000);
            Console.WriteLine($"---> Task action [{name}] is ending");
        }

    }
}
