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
        private bool _started;
        private DateTime _startTime;
        
        public BaseDevice(int r)
        {
            _id = _counter++;
        }        

        protected bool Started
        {
            get
            {
                return _started;
            }
        }


        protected DateTime StartTime
        {
            get
            {
                return _startTime;
            }
        }

        public virtual string GetInfo()
        {
            return string.Format(" ID = {0}", _id);
        }

        public void Start()
        {
            if (!_started)
            {
                _started = true;
                Console.WriteLine("{0}{1} Started", GetType().Name, GetInfo());

                _startTime = DateTime.Now;
            }
        }

        public void Stop()
        {
            if (_started)
            {
                _started = false;                 
                Console.WriteLine("{0}{1} Stopped", GetType().Name, GetInfo());
            }
        }
    }
}
