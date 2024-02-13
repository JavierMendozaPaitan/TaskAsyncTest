namespace ThreadExcercise01
{
    internal class ThreadExcercise1
    {
        static void Main(string[] args)
        {
            Thread thread01 = new Thread(new ThreadStart(TextToConsole01));
            Thread thread02 = new Thread(new ThreadStart(TextToConsole02));

            thread01.Start();
            thread02.Start();

            for (int i = 500; i < 600; i++)
            {
                Console.WriteLine($"Text from Main thread [{i}]");
                Thread.Sleep(300);
            }

            Console.ReadLine();
        }

        public static void TextToConsole01()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Text from Secundary thread [{i}]");
                Thread.Sleep(300);
            }
        }

        public static void TextToConsole02()
        {
            for (int i = 200; i < 300; i++)
            {
                Console.WriteLine($"Text from Third thread [{i}]");
                Thread.Sleep(300);
            }
        }
    }
}
