using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Classes
{
    public class Program2
    {
        public static void Main()
        {
            var p = new Person();

            p.Name = "John";

            p.Print();

            p.Save();
        }
    }

    internal static class PersonExt
    {
        public static void Print(this Person p)
        {
            Console.WriteLine("Person Name: " + p.Name);
        }
    }
}
