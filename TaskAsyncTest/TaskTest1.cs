using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskAsyncTest
{
    public class TaskTest1
    {
        public static void Main()
        {
            Thread.CurrentThread.Name = "Main";

            // Create a task and supply a user delegate by using a lambda expression.
            Task taskA = new Task(() =>
            {
                Console.WriteLine("---> Inside TaskA: Hello from taskA.");
                Console.WriteLine();
                Thread.Sleep(7000);
                Console.WriteLine("---> Inside TaskA: End of taskA.\n");
            });
            Console.WriteLine($"TaskA Created and Starting. Status: [{taskA.Status}]");
            // Start the task.
            taskA.Start();
            Thread.Sleep(500);

            Console.WriteLine($"TaskA Started. Status: [{taskA.Status}]\n");

            taskA.Wait();

            Console.WriteLine($"TaskA after Waited. Status: [{taskA.Status}]\nWait for three seconds...");

            //await Task.Delay(3000);
            Thread.Sleep(3000);

            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.",
                              Thread.CurrentThread.Name);

            
            

            Console.ReadKey();
        }
    }
}
