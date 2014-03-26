using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any string:");

            string st = Console.ReadLine();

            Console.WriteLine("You have entered: " + st);

            for (int k = 0; k < st.Length; k++)
                Console.WriteLine(st[k]);

            for (int k = 0; k < st.Length; k++)
                Console.Write(st[k]);

            Console.WriteLine();

            for (int k = st.Length - 1; k >= 0; k--)
                Console.Write(st[k]);

            Console.WriteLine(); Console.WriteLine();
        }
    }
}
