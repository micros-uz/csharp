using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _16_Threading
{
    public class DeadLock
    {
        private int _badSharedState = 0;
        private readonly object _lock1 = new object();
        private readonly object _lock2 = new object();

        public void Go()
        {
            new Thread(BadGuy1).Start();
            new Thread(BadGuy2).Start();

            Console.WriteLine("Leaving Go!");
        }

        public void BadGuy1()
        {
            lock (_lock1)
            {
                Thread.Sleep(10); // yeild with the lock is bad
                lock (_lock2)
                {
                    _badSharedState++;
                    Console.WriteLine("From Bad Guy #1: {0})", _badSharedState);
                }
            }
        }

        public void BadGuy2()
        {
            lock (_lock2)
            {
                lock (_lock1)
                {
                    _badSharedState++;
                    Console.WriteLine("From Bad Guy #2: {0})", _badSharedState);
                }
            }
        }
    }
}
