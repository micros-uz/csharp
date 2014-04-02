using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Avionika.Devices
{
    internal sealed class VoltageSensor : Sensor
    {
        protected override void Generate()
        {
            var x = DateTime.Now.Millisecond;
            Console.WriteLine("Voltage = 1." + (x ^ 435).ToString());
        }
    }
}
