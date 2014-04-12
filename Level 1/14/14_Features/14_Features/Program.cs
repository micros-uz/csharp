using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Features
{
    public partial class Class1
    {
        partial void Z()
        {
            Console.WriteLine("Z");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var obj = new Class1();

            obj.X();

            int n = 0;
            Work(ref n);

            var c = new Class1();
            c.MyProperty2 = 90;
            Work2(ref c);

            int s;
            Work3(out s);

            int q =0;
            int.TryParse("12312", out q);

            var db = DbManager.Instance;
            db.X();




            //del.Work(new Class2());

            Del2<Class1> del2 = X;

        }

        private static void X(Class1 obj)
        {
        }

        private static void Work2(ref Class1 a)
        {
            a = new Class1();
        }

        static void Work(ref int x)
        {
            //x = 9;
        }

        static void Work3(out int x)
        {
            //int w = x;

            x = 9;
        }
    }
}
