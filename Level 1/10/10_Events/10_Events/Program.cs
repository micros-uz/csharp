using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10_Events
{
    delegate void ThreadEndEvent(DateTime time);
    class A
    {
        B b;
        public A() 
        { 
            b = new B();
            b.ThreadEnd += x => Console.WriteLine("Time2 = " + x);
            b.ThreadEnd += x => { /*Debugger.Break(); */Console.WriteLine("Time3 = " + x); };
            b.Do(); 

        }

        void X(DateTime time) { Console.WriteLine("Time = " + time); }
    }

    class B
    {
        ThreadEndEvent _del;
        internal void Do()
        {
            new Thread(x =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("END");
                //new B().Do();

                if (_del != null) _del(DateTime.Now);
            }).Start();
        }

        internal event ThreadEndEvent ThreadEnd
        {
            add
            {
                _del += value;
            }
            remove
            {
                _del -= value;
            }
        }

        //internal event EventHandler e1;
        //internal event Func<int> e1;
    }

    class Program
    {
        static void Main(string[] args)
        {
            new A();
            Console.WriteLine("GAME OVER");
        }
    }
}
