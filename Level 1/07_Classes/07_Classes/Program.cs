using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Classes
{
    class Program
    {
        static void Main2(string[] args)
        {
            bool? b;

            b = null;
            b = true;
            b = false;

            if (b.HasValue)
                Console.WriteLine(b);

            var n = b.HasValue ? ((b.Value) ? 3 : 2) : 1;

            Console.WriteLine(n);

            int? x = null;

            x = 90;

            int r = x.Value;

        }

        private void x(Program _this, int e)
        {
            var w = this;
        }
    }
}
