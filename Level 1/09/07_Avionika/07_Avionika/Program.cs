using _07_Avionika.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Avionika
{
    class Program
    {
        static void Main(string[] args)
        {
            var bs = new BoardSystem();

            var el = bs.Devices[0];
            //var el2 = bs[345345];

            //bs.Devices = null;

            foreach (var item in bs.Devices)
            {
                Console.WriteLine(item);
            }

            bs.Run();
        }
    }
}
