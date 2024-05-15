using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsync4
{
	internal class Program
	{
        private static int counter = 0;
		static void Main(string[] args)
		{

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
				{
					counter++;

                    Console.Write($"{counter}|");
                    Thread.Sleep(1000);
                }
            }, cancellationToken);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            Console.WriteLine(" --> Sending Cancel signal to Task by Cancellation Token...");
            cancellationTokenSource.Cancel();
            while(!task.IsCompleted)
            {
                Console.WriteLine($"task status: [{task.Status}]");
                Thread.Sleep(100);
            }
            Console.WriteLine($"task status: [{task.Status}]");

            Console.ReadKey();

		}
	}
}
