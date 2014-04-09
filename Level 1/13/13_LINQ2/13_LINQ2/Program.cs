using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_LINQ2
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

            Console.WriteLine(list.Sum(x => x.Age));
            Console.WriteLine(list.Max(x => x.Age));
            Console.WriteLine(list.Min(x => x.Age));

            var p = list.Where(x => x.Name.StartsWith("A")).FirstOrDefault();

            Console.WriteLine(p.Name);

            var p2 = list.Where(x => x.Name.StartsWith("A") || x.Age < 25);

            p2.ToList().ForEach(x => Console.WriteLine(x.Name));


            var names = list.Where(x => x.Age > 40).Select(x => x.Name);
            names.ToList().ForEach(x => Console.WriteLine(x));

            var o = list.Select(x => new
            {
                FirstName = x.Name,
                BirthDay = DateTime.Now.AddYears(-x.Age)
            }).ToList();

            var b = list.Any(x => x.Name.Contains("z"));

            var sorted = list.OrderBy(x => x.Name).ThenBy(x => x.Age).ToList();

            var p3 = list.Select(x => new { Person = x, Time = DateTime.Now });


        }
    }
}
