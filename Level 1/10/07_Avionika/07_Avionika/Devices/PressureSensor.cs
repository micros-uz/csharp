using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Avionika.Devices
{
    internal sealed class PressureSensor : Sensor
    {
        protected override void Generate()
        {
            var x = DateTime.Now.Millisecond;
            Console.WriteLine("Pressure = 4." + x);
        }
    }
}
