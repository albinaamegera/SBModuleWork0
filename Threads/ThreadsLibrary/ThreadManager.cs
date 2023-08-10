using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsLibrary
{
    public class ThreadManager
    {
        private int count;
        private int counter = 0;
        private Random random = new();
        private char[] charCollection = new char[3] { '#', '@', '$' };

        public ThreadManager(int count) => this.count = count;
        public ThreadManager() : this(3) { }

        public void Start(bool flag)
        {
            Thread bgThread = new Thread(Counter);
            bgThread.IsBackground = true;
            bgThread.Start();

            for (int i = 0; i < count; i++)
            {
                Thread thread = new Thread(Print);
                thread.Start(charCollection[i]);
                if (flag) thread.Join();
            }

            Console.WriteLine($"Background thread has finished work with result : {counter}");
        }
        private void Print(object? c)
        {
            var currentThread = Thread.CurrentThread;
            currentThread.Name = "Additional Thread";
            Console.WriteLine($"\n{currentThread.Name} number {currentThread.ManagedThreadId} has started work");

            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{c} ");
                Thread.Sleep(random.Next(100, 150));
            }

            Console.WriteLine($"\n{currentThread.Name} number {currentThread.ManagedThreadId} has finished work");
        }
        private void Counter()
        {
            while (true)
            {
                counter++;
                Thread.Sleep(random.Next(50, 100));
            }
        }
    }
}
