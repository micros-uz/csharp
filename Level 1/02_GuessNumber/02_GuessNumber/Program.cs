using School50;
using System;

namespace _02_GuessNumber
{
    class Program
    {
        static Class10 c;

        private const int MAX_TRY_Count = 7;

        static void Main(string[] args)
        {
            c = new Class10(new XXX.xxx());

            //var e = c.m1();

            int x = GetRandomNumber();
            int tryCount = 0;
            string[] tryMas = new string[MAX_TRY_Count];

            while (true)
            {
                Print("Enter your number (from 1 to 100):");

                string st = Console.ReadLine();

                if (st == string.Empty)
                    break;

                if (NotExists(tryMas, st))
                {
                    tryMas[tryCount] = st;

                    if (CheckResult(st, x))
                        break;

                    if (++tryCount >= MAX_TRY_Count)
                    {
                        Print("Game Over! You are looser...");
                        break;
                    }
                }
            }
        }

        private static bool NotExists(string[] tryMas, string st)
        {
            foreach (var item in tryMas)
            {
                if (item == st)
                    return false;
            }

            return true;
        }

        private static bool CheckResult(string st, int a)
        {
            int result;

            if (int.TryParse(st, out result))
            {
                if (result == a)
                {
                    Print("You have won!");
                    return true;
                }
                else if (result < a)
                    Print("Your number is less");
                else
                    Print("Your number is greater");
            }
            else
                Print("BAD");

            return false;
        }

        private static int GetRandomNumber()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            return r.Next(100);
        }

        private static void Print(string st)
        {
            Console.WriteLine(st);
        }
    }
}



