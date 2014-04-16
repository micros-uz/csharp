using System;
using System.Diagnostics;
using System.Threading;

namespace _16_Threading
{
    class AtomicIncrement
    {
        private const int MaxThraedCount = 10;
        private Thread[] m_Workers = new Thread[MaxThraedCount];
        private volatile int m_Counter = 0;
        private Int32 x = 0;
        private Stopwatch m_Watcher = new Stopwatch();

        public void Go()
        {
            Console.WriteLine("Starting...");

            m_Watcher.Start();
            for (int i = 0; i < MaxThraedCount; i++)
            {
                m_Workers[i] = new Thread(IncreaseNumber) { Name = "Thread " + (i + 1) };
                m_Workers[i].Start();
            }
        }

        void IncreaseNumber()
        {
            try
            {
                for (int i = 0; i < 100000; i++)
                {
                    // Different strategy to increment x
                    // wrong way - without any code
                    //x++;

                    //1) 
                    //lock (this)
                    //    x++;

                    //2) 
                    //Interlocked.Increment(ref x);
                }

                Console.WriteLine(String.Format("{0} finished at {1}", Thread.CurrentThread.Name, m_Watcher.Elapsed.TotalMilliseconds));

                // Increases Counter and decides whether or not sets the finish signal
                m_Counter++;
                if (m_Counter == MaxThraedCount)
                {
                    m_Watcher.Stop();
                    // Print finish information on UI
                    Console.WriteLine("\r\nAll Done at: " + m_Watcher.Elapsed.TotalMilliseconds);
                    Console.WriteLine("The result: " + x.ToString());
                    m_Counter = 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
