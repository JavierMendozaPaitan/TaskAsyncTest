using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncTest6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var t = Task<int>.Run( () => {
                                      // Just loop.
                                      int max = 10;
                                      int ctr = 0;
                                      for (ctr = 0; ctr <= max; ctr++) 
                                      {
                                         Console.WriteLine($"Iteration: [{ctr}]");
                                         if (ctr == max / 2 && DateTime.Now.Hour <= 12) 
                                         {                                            
                                            ctr++;
                                            break;
                                         }
                                         Thread.Sleep(100);
                                      }

                                      return ctr;
                                    } );
            Console.WriteLine("Finished {0:N0} iterations.", t.Result);

            Console.ReadLine();

            //###############################

            var task = Task<int>.Factory.StartNew( () => {
                                      // Just loop.
                                      int max = 1000000;
                                      int ctr = 0;
                                      for (ctr = 0; ctr <= max; ctr++) {
                                         if (ctr == max / 2 && DateTime.Now.Hour <= 12) {
                                            ctr++;
                                            break;
                                         }
                                      }
                                      return ctr;
                               } );
            Console.WriteLine("Finished {0:N0} iterations.", task.Result);

            Console.ReadLine();
		}
	}
}
