using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncTest2
{
	internal class TaskTest2
	{
		static void Main(string[] args)
		{
			 Action<object> action = (object obj) =>
                                {
                                    Console.WriteLine($"Task {obj} started");
                                    Console.WriteLine("--> TaskId={0}, name={1}, ThreadId={2}",
                                        Task.CurrentId, obj,
                                        Thread.CurrentThread.ManagedThreadId);
                                    Thread.Sleep(2000);
                                    Console.WriteLine($"Task {obj} finished\n");
                                };

            // Create a task but do not start it.
            Task taskAlpha = new Task(action, "alpha");

            // Construct a started task
            Task taskBeta = Task.Factory.StartNew(action, "beta");
            Console.WriteLine($"Task beta launched. Status: [{taskBeta.Status}]");
            // Block the main thread to demonstrate that t2 is executing
            taskBeta.Wait();

            // Launch t1 
            Console.WriteLine($"Task alpha launched. Status: [{taskAlpha.Status}]");
            taskAlpha.Start();
            // Wait for the task to finish.
            taskAlpha.Wait();

            // Construct a started task using Task.Run.
            String taskData = "delta";
            Task taskDelta = Task.Run( () => {
                Console.WriteLine($"Task {taskData} started");
                Console.WriteLine("-->TaskId={0}, name={1}, ThreadId={2}",
                    Task.CurrentId, taskData, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                Console.WriteLine($"Task {taskData} finished\n");
            });
            Console.WriteLine($"Task {taskData} launched. Status: [{taskDelta.Status}]");
            // Wait for the task to finish.
            taskDelta.Wait();

            //Task.WaitAll();

            Console.ReadKey();
		}
	}
}
