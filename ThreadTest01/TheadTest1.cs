namespace ThreadTest01
{
    public class TheadTest1
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(TextToConsole));
            thread.Start();

            for (int i = 500; i < 600; i++)
            {
                Console.WriteLine($"Text from Main thread [{i}]");
                Thread.Sleep(1000);
            }

            thread.Join();

            Console.ReadLine();
        }

        public static void TextToConsole() 
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Text from Secundary thread [{i}]");
                Thread.Sleep(500);
            }
        }
    }
}
