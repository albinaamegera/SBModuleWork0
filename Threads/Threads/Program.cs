using ThreadsLibrary;

namespace Threads
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new();
            ThreadManager tm = new(random.Next(1, 4));

            tm.Start(false);

            Console.ReadKey();
        }
    }
}
