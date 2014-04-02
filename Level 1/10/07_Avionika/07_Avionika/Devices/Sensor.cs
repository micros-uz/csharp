using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _07_Avionika.Devices
{
    internal abstract class Sensor : BaseDevice
    {
        private Timer _timer;
        public Sensor() :base()
        {
            _timer = new Timer(1500);
            _timer.Elapsed += (s, e) => 
            {
                Generate(); 
                //var p = new Process();
                //p.StartInfo.FileName = "Notepad.exe";
                //p.Start();
            };
            _timer.Start();
        }

        protected abstract void Generate();
    }
}
