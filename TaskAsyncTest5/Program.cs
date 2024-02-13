using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncTest5
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var tasks = new Task[3];
            var rnd = new Random();

            for (int ctr = 0; ctr <= 2; ctr++)
                tasks[ctr] = Task.Run( () => Thread.Sleep(rnd.Next(500, 3000)));

            try {
                int index = Task.WaitAny(tasks);

                Console.WriteLine("Task #{0} completed first.\n", tasks[index].Id);
                Console.WriteLine("Status of all tasks:");
                foreach (var t in tasks)
                Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);
            }
            catch (AggregateException) {
                Console.WriteLine("An exception occurred.");
            }

            Console.ReadLine();
            //#######################################

            Task[] taskList = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                taskList[i] = Task.Run(() => Thread.Sleep(2000));
            }

            try {
                Task.WaitAll(taskList);
            }
            catch (AggregateException ae) {
                Console.WriteLine("One or more exceptions occurred: ");
                foreach (var ex in ae.Flatten().InnerExceptions)
                Console.WriteLine("   {0}", ex.Message);
            }   

            Console.WriteLine("Status of completed tasks:");
            foreach (var t in taskList)
                Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);


            Console.ReadLine();

		}
	}
}
