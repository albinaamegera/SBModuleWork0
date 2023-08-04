namespace Threads
{
    class Program
    {
        static Random random = new();
        static void Print()
        {
            var currentThread = Thread.CurrentThread;
            currentThread.Name = "Additional Thread";

            for (int i = 0; i < 100; i++)
            {
                Console.Write("@ ");
                Thread.Sleep(random.Next(100, 150));
            }

            Console.WriteLine($"\n{currentThread.Name} number {currentThread.GetHashCode()} has finished work");
        }
        public static void Main(string[] args)
        {
            var mainThread = Thread.CurrentThread;
            mainThread.Name = "Main Thread";

            var additionalthread = new Thread(Print);
            
            additionalthread.Start();
            additionalthread.Join();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("% ");
                Thread.Sleep(random.Next(110, 160));
            }
            Console.WriteLine($"\n{mainThread.Name} has finished work");
            Console.ReadKey();
        }
    }
}
