using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringDelegate del = null;
            
            del += Down;
            del += Up;

            var st = "Hello";
            Print(st, del);
            //
            st = "World";
            Print(st, del);

            Act act = null;
            act += new Act(Act1);
            act += Act2;
            Do(act);

            act -= new Act(Act1);
            Do(act);

            Do(new Act(delegate 
                {
                    //act();
                    Console.WriteLine("Anonimous delegate");
                }));

            Do2(Console.WriteLine);

            Do2(new ActStr(delegate(string s)
                {
                    Console.WriteLine(s.ToUpper());
                }));

            Do(() => { Console.WriteLine("Simple Lambda"); });

            Do2(x => Console.WriteLine(x));

            Do3((s1, s2) => { });
        }

        static void Print(string st, StringDelegate method)
        {
            if (method != null)
                st = method(st);

            Console.WriteLine(st);
        }

        static void Do(Act act)
        {
            if (act != null) act();
        }

        static void Do2(ActStr act)
        {
            if (act != null) act("Hi everybody!");
        }

        static void Do3(ActStr2 act)
        {
            if (act != null) act("Hi everybody!", "fefe");
        }

        static string Up(string st)
        {
            Console.WriteLine("Up: " + st);
            return st.ToUpper();
        }

        static string Down(string st)
        {
            Console.WriteLine("Down: " + st);
            return st.ToLower();
        }

        static void Act1()
        {
            Console.WriteLine("Act1: " + DateTime.Now);

            //return 0;
        }

        static void Act2()
        {
            Console.WriteLine("Act1: " + Environment.UserName);
        }
    }
}
