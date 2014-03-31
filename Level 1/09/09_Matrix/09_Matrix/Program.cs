using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var m1 = new Matrix { A = 100, A1 = 200, B = 300, B1 = 400 };
            var m2 = new Matrix { A = 10, A1 = 15, B = 8, B1 = 4 };

            Console.WriteLine(m1.ToString());
            Console.WriteLine(m2.ToString());

            var m3 = m1 + m2;

            Console.WriteLine(m3.ToString());

            var m4 = m3++;

            m4++;

            Console.WriteLine(m4.ToString());

            int x = m1;

            Console.WriteLine(x);

            Matrix m = (Matrix)x;

            Console.WriteLine(m.ToString());
        }
    }
}
