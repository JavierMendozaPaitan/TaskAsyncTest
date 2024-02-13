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
            cancellationTokenSource.Cancel();
            Console.WriteLine($"Task executed {counter} times");

            Console.ReadKey();

		}
	}
}
