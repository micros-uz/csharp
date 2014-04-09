using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_TestCSharpMemory
{
    class A
    {
        public int n;
        public long l;
        public string s;

        public virtual void x() { }
    }

    struct B
    {
        public int n;
        public long l;
        public string s;
    }

    class Program
    {
        unsafe static void Main(string[] args)
        {
            int* n = null;
            int[] m = new int[] { 3, 4 };

            int x = 7;

            n = &x;

            *n = 45;

            fixed (int* a = &m[0])
            {
                *a = 5;
                *(a + 4) = 7;
            }

            A aa = null;

            aa = new A();

            B b;
            b.l = 0x1234567812345678;
            b.n = 0x79999999;
            b.s = "STRUCT";
        }
    }
}
