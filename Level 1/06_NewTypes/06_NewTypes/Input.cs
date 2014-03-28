using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_NewTypes
{
    internal static class Input
    {
        internal static void Print(string s)
        {
           Console.WriteLine(s);
        }

        internal static string GetStr(string s)
        {
            Console.WriteLine(s);

            return Console.ReadLine();
        }

        internal static int GetInt(string s)
        {
            try
            {
                return Convert.ToInt32(GetStr(s));
            }
            catch(FormatException)
            {
                return int.MinValue; 
            }
        }
    }
}
