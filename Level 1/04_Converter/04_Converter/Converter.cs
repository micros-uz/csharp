using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Converter
{
    public class Converter
    {
        public static void Main()
        {
            string st = Console.ReadLine();

            int n = ToInt(st);

            Console.WriteLine(n);
        }

        public static int ToInt(string st)
        {
            int res = 0;

            for (int k = st.Length - 1; k >= 0; k-- )
            {
                char c = st[k];
                int n = (byte)c - 0x30;

                int a = st.Length - k - 1;

                res = res + (int)Math.Pow(10, a) * n;
            }

            return res;
        }
    }
}
