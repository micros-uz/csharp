using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Features
{
    public partial class Class1
    {
        int r;
        int MyProperty { get; set; }
        public int MyProperty2 { get; set; }

        public void X()
        {
            Console.WriteLine("X");
            Z();
        }

        partial void Z();
    }

    public class Class2 : Class1
    {

    }
}
