namespace MultithreadTest01
{
    public class MultithreadTest1
    {        
        static void Main(string[] args)
        {
            List<string> urls = new(){
                                        "https://www.google.com/",
                                        "https://www.duckduckgo.com/",
                                        "https://www.yahoo.com/",
                                     };

            List<Thread> threads = [];

            urls.ForEach(url => threads.Add(new Thread(() => CheckHttpStatusForUrl(url))));
            threads.ForEach( thread => thread.Start());
            threads.ForEach (thread => thread.Join());

            Console.ReadLine();
        }

        public static void CheckHttpStatusForUrl(string url)
        {
            HttpClient client = new();
            var response = client.GetAsync(url).Result;
            Thread.Sleep(9000);
            Console.WriteLine($"Status for {url} is {response.StatusCode}");
            
        }
    }
}
