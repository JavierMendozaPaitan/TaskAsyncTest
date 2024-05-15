namespace AsyncTest01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var task = Method01Async();
            //Method03();
            //Method02Async(); 

            Console.WriteLine($"Working in the main thread");

            Console.WriteLine("Press key to continue");
            Console.ReadLine();
        }
              

        private static async Task Method01Async()
        {
            await Task.Run(async () =>
            {
                Console.WriteLine($"Launching task [{Task.CurrentId}]");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Method 1 value [{i}]");
                    await Task.Delay(200);
                }
            });
        }

        private static void Method03()
        {
            for (int i = 200; i < 300; i++)
            {
                Console.WriteLine($"Method 3 value [{i}]");
                Task.Delay(200).Wait();
            }
        }

        private static async Task Method02Async()
        {
            await Task.Run(() =>
            {
                for (int i = 100; i < 200; i++)
                {
                    Console.WriteLine($"Method 2 value [{i}]");
                    Task.Delay(200).Wait();
                }
            });
        }

    }
}
