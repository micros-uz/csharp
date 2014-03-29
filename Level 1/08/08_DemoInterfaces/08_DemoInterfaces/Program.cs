using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DemoInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mas = new string[]{"28052014", "14042014", "01012015"};

            IComparer c = new MyComparer();

            Array.Sort(mas, c);

            foreach (var item in mas)
            {
                Console.WriteLine(item);
            }
        }
    }
}
