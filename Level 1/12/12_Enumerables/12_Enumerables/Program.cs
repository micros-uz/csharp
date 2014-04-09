using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Enumerables
{
    class Program
    {
        static void Main(string[] args)
        {

            var lib = new Library2()
            //lib.Add(new Book { Title = "Uzbekistan XXI asr", Year = 1996 });
            //lib.Add(new Book { Title = "Repka", Year = 2014 });

            { 
                new Book {Title = "Uzbekistan XXI asr", Year = 1996},
                new Book {Title = "Repka", Year = 2014}
            };

            foreach (var item in "12345")
            {
                Console.WriteLine(item);
            }

            var enumerator = "12345".GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            foreach (var item in lib)
            {
                Console.WriteLine(item);
            }

            foreach (var item in lib)
            {
                Console.WriteLine(item);
            }

            foreach (var item in lib.Backwards)
            {
                Console.WriteLine(item);
            }
        }
    }
}
