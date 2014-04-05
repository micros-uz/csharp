using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ArrayList();

            a.Add(234);
            a.Add(234);
            a.Add(4444444);
            a.Add(234);
            a.Add(2341234);

            a.RemoveAt(0);
            a.Remove(4444444);

            Display(a);

            a[0] = DateTime.Now.AddMonths(-1);

            Display(a);

            int count = a.Count;
            int idx = a.IndexOf(234);

            a.Insert(2, 999999);

            Display(a);

            bool b = a.Contains(999999);

            a.Reverse(0, a.Count);

            Display(a);

            var mas = a.ToArray();

            a.SetRange(0, new [] {1, 3, 2, 3});

            Display(a);

            var s = new Stack();

            s.Push(22);
            s.Push(33);
            s.Push(44);

            Display(s);

            var x = s.Pop();

            Display(s);

            var q = new Queue();

            q.Enqueue(111);
            q.Enqueue(222);
            q.Enqueue(333);

            Display(q);

            var e = q.Dequeue();

            Display(q);

            
        }

        private static void Display(IEnumerable a)
        {
            Console.WriteLine("____________________");

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
