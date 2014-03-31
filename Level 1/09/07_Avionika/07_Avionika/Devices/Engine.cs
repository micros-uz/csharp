using System;

namespace _07_Avionika.Devices
{
    internal sealed class Engine : BaseDevice
    {
        private string _type;

        public Engine(string type) : base(0)
        {
            _type = type;
        }

        public override string GetInfo()
        {
            var res =  base.GetInfo() + " " + _type;

            if (!Started)
            {
                var time = (int)(DateTime.Now - StartTime).TotalMilliseconds;

                
                res += string.Format(" (Work Time = {0}ms) ", time);
            }

            return res;
        }
    }
}
