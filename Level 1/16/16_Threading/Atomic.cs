
using System;
using System.Threading;
namespace _16_Threading
{
    struct SolidStruct
    {
        public SolidStruct(ulong value)
        {
            A = B = C = D =value;
        }

        public readonly ulong A;
        public readonly ulong B;
        public readonly ulong C;
        public readonly ulong D;

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", A, B, C, D);
        }
    }

    class Atomic
    {
        static SolidStruct s_value;

        public static void Go()
        {
            Thread t = new Thread(LookAtValue);
            t.IsBackground = true;
            t.Start();

            for (ulong i = 0; i < ulong.MaxValue; ++i)
            {
                s_value = new SolidStruct(i);
            }
        }

        static void LookAtValue()
        {
            while (true)
            {
                SolidStruct value = s_value;
                if (value.A != value.B || value.B != value.C
                    || value.C != value.D)
                {
                    Console.WriteLine(value);
                }

                Console.ReadLine();
            }
        }
    }
}
