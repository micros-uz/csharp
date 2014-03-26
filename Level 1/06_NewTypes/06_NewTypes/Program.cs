using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_NewTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            Person p;

            //x = x + 1;
            p = new Person(22, "Ibragim");

            p.phone = "77-18-03sfgasdflkgjasd;lkgjasdkl;g";
            p.navbatKuni = Day.Wed;

            int q = (int)p.navbatKuni;
            int a = p.Age;
            p.Age = 90;

            Save(p);
            p.Save();

            ArrayList list = new ArrayList();

            while (true)
            {
                string name = Input.GetStr("Enter the name:");

                if (string.IsNullOrWhiteSpace(name)) break;

                int age = Input.GetInt("Enter the age:");

                if (age == int.MinValue) break;

                var person = new Person(age, name);
                list.Add(person);
            }

            Print(list);
        }

        static void Save(Person p)
        {
            //Console.WriteLine(p.name);
        }

        static void Save(Person p, int r)
        {
            //Console.WriteLine(p.name);
        }

        static void Print(ArrayList array)
        {
            foreach (var item in array)
            {
                Person p = item as Person;
                Input.Print(p.FullName);
            }


            new Person().Save();


        }
    }
}
