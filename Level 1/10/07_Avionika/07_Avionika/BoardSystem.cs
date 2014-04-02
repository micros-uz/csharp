using _07_Avionika.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace _07_Avionika
{
    internal class BoardSystem
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

        //private List<IBaseDevice> Devices;

        public BoardSystem()
        {
            Configure();
        }

        internal List<IBaseDevice> Devices
        {
            get;
            private set;
        }

        internal IBaseDevice this[int index]
        {
            get
            {
                return Devices[index];
            }
        }

        internal void Run()
        {
            //MessageBox(IntPtr.Zero, "234234234", "Caption", 0);

            Console.WriteLine("BoardSystem v1.0 starting up...");

            while (true)
            {
                var key = Console.ReadKey(true);

                if (!ProcessKey(key))
                    break;
            }

            var t = Process.GetCurrentProcess().Threads;

            Console.WriteLine("GAME OVER");
        }

        private void Configure()
        {
            Devices = new List<IBaseDevice>()
            {
                new Engine("Left"),
                new Engine("Right"),
                new PressureSensor(),
                new VoltageSensor()
            };

            //devices.Add(new Engine("Left"));
            //devices.Add(new Engine("Right"));
            //devices.Add(new PressureSensor());
            //devices.Add(new VoltageSensor());
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
            foreach (var item in Devices)
            {
                item.Start();
            }
        }

        private void Stop()
        {
            foreach (var item in Devices)
            {
                item.Stop();
            }
        }
    }
}
