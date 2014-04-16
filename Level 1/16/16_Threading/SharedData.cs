using System;
using System.IO;
using System.Threading;

namespace _16_Threading
{
    class SharedData
    {
        private bool _b;

        public void Go()
        {
            for (var k = 0; k < 10; k++)
            {
                var t = new Thread(Work);
                t.Name = "Go " + k;
                t.Start();
            }
        }

        private void Work()
        {
            
            for (var k = 0; k < 3000; k++)
            {
                //lock(this)
                if (_b)
                {
                    //Thread.Sleep(10);
                    File.Exists("c:\\bootmgr");
                    //Console.WriteLine("True {0}", _b);
                    if (!_b)
                    {
                        Console.WriteLine("True {0}", _b);
                    }
                    _b = false;
                }
                else
                {
                    //Thread.Sleep(10);
                    File.Exists("c:\\bootmgr");
                    //Console.WriteLine("False {0}", _b);
                    if (_b)
                    {
                        Console.WriteLine("False {0}", _b);
                    }
                    _b = true;
                }
            }
        }
    }
}
