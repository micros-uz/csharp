using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_LINQ3
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> list = new List<Person>()
            {
                new Person{Name = "John", Age = 45, Company = "MS"},
                new Person{Name = "John", Age = 90, Company = "IBM"},
                new Person{Name = "Azim", Age = 45, Company = "MS"},
                new Person{Name = "Nick", Age = 14, Company = "IBM"}
            };

            IList<Company> list2 = new List<Company>()
            {
                new Company{Name = "MS", Area = "Soft"},
                new Company{Name = "IBM", Area = "Hard"}
            };

            var res = (from p in list
                      where p.Age > 40
                       select p.Name).ToArray();

            var res2 = (from p in list
                        where p.Age > 25
                        group p by p.Name into p2
                        where p2.Key.StartsWith("A")
                        select new {Name = p2.Key, Sum = p2.Sum(x => x.Age)}).ToArray();

            var res3 = (from p in list
                        join c in list2 on p.Company equals c.Name
                        orderby p.Name 
                        select new { Name = p.Name, Area = c.Area }
                       ).Skip(1).Take(2).ToArray();

            var res4 = Enumerable.Range(10, 100).ToArray();

            var res5 = Enumerable.Repeat(10, 10).ToArray();
        }
    }
}
