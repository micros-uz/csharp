using System;

namespace _07_Avionika
{
    internal class Engine
    {
        private string _type;

        public Engine(string type)
        {
            _type = type;
        }

        internal void Start()
        {
            Console.WriteLine("Engine {0} Started", _type);
        }

        internal void Stop()
        {
            Console.WriteLine("Engine {0} Stopped", _type);
        }
    }
}
