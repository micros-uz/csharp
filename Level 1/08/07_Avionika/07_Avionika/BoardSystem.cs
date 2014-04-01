using _07_Avionika.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace _07_Avionika
{
    internal class BoardSystem
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);  

        private ArrayList devices;

        internal void Run()
        {
            MessageBox(IntPtr.Zero, "234234234", "Caption", 0);

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
            devices = new ArrayList();

            devices.Add(new Engine("Left"));
            devices.Add(new Engine("Right"));
            devices.Add(new Sensor());
            devices.Add(new Sensor());
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
            foreach (var item in devices)
            {
                ((IBaseDevice)item).Start();
            }
        }

        private void Stop()
        {
            foreach (var item in devices)
            {
                ((IBaseDevice)item).Stop();
            }
        }
    }
}
