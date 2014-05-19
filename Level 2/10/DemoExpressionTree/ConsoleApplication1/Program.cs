using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static IEnumerable<Customers> GetCustomers()
        {
            return new Customers[]
            {
                new Customers{Age=12, Name="John"},
                new Customers{Age=32, Name="John"},
                new Customers{Age=39, Name="John"},
                new Customers{Age=24, Name="Kalvin"},
                new Customers{Age=67, Name="Mike"},
                new Customers{Age=52, Name="Rose"}
            };
        }

        static void Main(string[] args)
        {
            var oldcustomers = GetCustomers().Where(x => x.Age > 50).Select(x => x.Name);
            foreach (var item in oldcustomers)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            Type t = typeof(Customers);
            ParameterExpression pe = Expression.Parameter(t);
            MemberInfo mi = t.GetField("Age");
            MemberExpression me = Expression.MakeMemberAccess(pe, mi);
            ConstantExpression c = Expression.Constant(50, typeof(int));
            BinaryExpression bi = Expression.GreaterThan(me, c);
            Expression<Func<Customers, bool>> efcb = Expression<Func<Customers, bool>>.Lambda<Func<Customers, bool>>(bi, pe);
            MemberInfo mi2 = t.GetField("Name");
            MemberExpression me2 = Expression.MakeMemberAccess(pe, mi2);
            Expression<Func<Customers, string>> efcb2 = Expression<Func<Customers, string>>.Lambda<Func<Customers, string>>(me2, pe);
            
            var customers = GetCustomers().Where(efcb.Compile());
            var names = GetCustomers().Select(efcb2.Compile());
            
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
