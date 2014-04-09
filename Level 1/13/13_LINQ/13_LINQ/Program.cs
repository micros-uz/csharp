using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using _13_LINQ_;

namespace _13_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> list = new List<Person>()
            {
                new Person{Name = "John", Age = 45},
                new Person{Name = "John", Age = 90},
                new Person{Name = "Azim", Age = 45},
                new Person{Name = "Nick", Age = 14}
            };

            int age = 0;
            foreach (var item in list)
            {
                if (item.Age > age)
                    age = item.Age;
            }

            Console.WriteLine(age);
            age = 1000;

            Perform(list, x => { if (x.Age < age) age = x.Age; });
            list.Perform(x => { if (x.Age < age) age = x.Age; });

            Console.WriteLine(age);

            Person p = null;
            foreach (var item in list)
            {
                if (item.Name.StartsWith("A"))
                {
                    p = item;
                    break;
                }
            }

            Console.WriteLine(p.Name);

            Perform(list, x =>
            {
                if (x.Name.StartsWith("A"))
                {
                    p = x;
                    return true;
                }else return false;
            });


            int sum = list.Sum(x => x.Age);
            Console.WriteLine(sum);
            Console.WriteLine(new[] { 1, 2, 5 }.Sum(x => x));
            Console.WriteLine(new[] { "John", "Azim", "Odil" }
                .Sum(x => x.Length));

            var proc = Process.GetProcesses();

            Console.WriteLine(proc.Sum(x => x.PrivateMemorySize));
        }

        static void Perform<T>(IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        static void Perform<T>(IEnumerable<T> list, Func<T, bool> func)
        {
            foreach (var item in list)
            {
                if (func(item))
                    break;
            }
        }
    }
}
