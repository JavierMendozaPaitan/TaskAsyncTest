namespace AsyncTest01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Method01Async();
            Method03();
            //Method02Async();  

            Console.WriteLine("Press key to continue");
            Console.ReadLine();
        }
              

        private static async Task Method01Async()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Method 1 value [{i}]");
                    Task.Delay(200).Wait();
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
