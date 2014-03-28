using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_Avionika
{
    internal class BoardSystem
    {
        private ArrayList engines;

        internal void Run()
        {
            Console.WriteLine("BoardSystem v1.0 starting up...");

            Configure();

            while(true)
            {
                var key = Console.ReadKey(true);

                if (!ProcessKey(key))
                    break;

            }

            Console.WriteLine("GAME OVER");
        }

        private void Configure()
        {
            engines = new ArrayList();

            engines.Add(new Engine("Left"));
            engines.Add(new Engine("Right"));
        }

        private bool ProcessKey(ConsoleKeyInfo key)
        {
            var res = true;

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    res = false;
                    break;
                case ConsoleKey.F5:
                    Start();
                    break;
                case ConsoleKey.F6:
                    Stop();
                    break;
                    
            }

            return res;
        }

        private void Start()
        {
            foreach (var item in engines)
            {
                ((Engine)item).Start();
            }
        }

        private void Stop()
        {
            foreach (var item in engines)
            {
                ((Engine)item).Stop();
            }
        }
    }
}
