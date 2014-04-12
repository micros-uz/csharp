using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Variativeness
{
   
    class Program
    {
        static void Main(string[] args)
        {
            IContainer<Shape> list = new Container<Shape>();

            Shape shape = new Circle();

            Shape[] mas = new Shape[2];
            mas[0] = new Circle();

            list = new Container<Circle>();

            IContainer2<Shape> list2 = new Container2<Circle>();

        }
    }
}
