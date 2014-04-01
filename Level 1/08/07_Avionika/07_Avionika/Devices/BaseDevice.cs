using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Avionika.Devices
{
    abstract class BaseDevice : IBaseDevice
    {
        private static int _counter;
        private int _id;
        
        public BaseDevice(int r)
        {
            _id = _counter++;
        }
        
        public virtual string GetInfo()
        {
            return string.Format(" ID = {0}", _id);
        }

        public void Start()
        {
            Console.WriteLine("{0}{1} Started", GetType().Name, GetInfo());
        }

        public void Stop()
        {
            Console.WriteLine("{0}{1} Stopped", GetType().Name, GetInfo());
        }
    }
}
