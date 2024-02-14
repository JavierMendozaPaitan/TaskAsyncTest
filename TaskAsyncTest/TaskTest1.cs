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
                Console.WriteLine("Hello from taskA.");
                Console.WriteLine();
                Thread.Sleep(5000);
                Console.WriteLine("End of taskA.");
            });
            Console.WriteLine($"######### taskA: [{taskA.Status}]");
            // Start the task.
            taskA.Start();

            Console.WriteLine($"######### taskA: [{taskA.Status}]");

            taskA.Wait();

            Console.WriteLine($"######### taskA: [{taskA.Status}]");

            Thread.Sleep(2000);


            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.",
                              Thread.CurrentThread.Name);

            
            

            Console.ReadKey();
        }
    }
}
