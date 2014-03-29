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
            return base.GetInfo() + " " + _type;
        }

        //internal void Start()
        //{
        //    Console.WriteLine("Engine {0} Started", _type);
        //}

        //internal void Stop()
        //{
        //    Console.WriteLine("Engine {0} Stopped", _type);
        //}
    }
}
