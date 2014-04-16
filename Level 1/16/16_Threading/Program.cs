
using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace _16_Threading
{
    class Program
    {
        static object _lock = new object();

        static void Main(string[] args)
        {
            //1) Back and Fore (prevents exit)


            //a) just hangs new Thread(x => { while (true); }).Start();

            //b) does not hang - set to Backgound
            //var t = new Thread(x => { while (true) (x as Thread).IsBackground = true; });
            //t.Start(t);

            //c) - use normal Background
            //var bw = new BackgroundWorker();
            //bw.DoWork += (sender, e) => { while (true); };
            //bw.RunWorkerAsync();   


            //2) Try to work simultaneously
            //a) Work('A'); Work('B');
            //b) new Thread(Work).Start('A');
            //b) new Thread(Work).Start('B');

            //3) Shared Data
            //new SharedData().Go();

            //4) Atomic assignment
            //Atomic.Go();

            //4) Atomic increment
            //new AtomicIncrement().Go();

            //6) Deadlock
            //new DeadLock().Go();

            //7) ThreadPool
            //ThreadPool.QueueUserWorkItem(RunInPool, 1);
            //ThreadPool.QueueUserWorkItem(RunInPool, 2);

            //8) TPL
            //Parallel.For(0, 10/*0000*/, x => Console.Write("ID = {0} ", Thread.CurrentThread.ManagedThreadId));
            //var lines = File.ReadAllLines(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ThirdPartyNotices.txt");
            //Parallel.ForEach(lines.SelectMany(x => x.ToCharArray()), x => Console.Write("{0}", x/*, Thread.CurrentThread.ManagedThreadId*/));
        }

        private static void RunInPool(object state)
        {
            Thread.CurrentThread.Name = "RunInPool " + state;

            while (true)
            {
                Thread.Sleep(100);
            }
        }

        static void Work(object ch)
        {
            for (var i = 0; i < 300; i++)
            {
                lock (_lock)
                {
                    for (var k = 0; k < 5; k++)
                    {
                        Console.Write(ch);
                    }
                    Console.Write("|");
                }
            }
        }
    }
}
