using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _11_CustomCollection
{
    class P : Program { }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new PrintableList<int>();

            list.Add(11);
            list.Add(33);
            list.Add(55);

            list.Display();

            var list2 = new PrintableList<string>();

            list2.Add("aaa");
            list2.Add("bbb");
            list2.Add("ccc");

            list2.Display();


            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }

            list.Display();

            var ints = GetArray<int>();
            var sts = GetArray<long>();

            var dict = new Dictionary<int, Program>();
            dict.Add(1, new Program());
            dict.Add(345, new Program());
            dict.Add(9999, new Program());

            var p = dict[345];

            GetDict<int, P>();
        }

        static Elem[] GetArray<Elem>() where Elem : struct
        {
            return new Elem[10];
        }

        static Dictionary<K, V> GetDict<K, V>() where V : Program, new()
        {
            return new Dictionary<K, V>();
        }

        static List<V> GetDict2<K, V>()
            where K : class, V, new()
            where V : IComparable
        {
            var p = Create<Program>();
            var list = Create<PrintableList<int>>();

            return new List<V>();
        }

        static T Create<T>() where T : new()
        {
            return new T();
        }
    }
}
