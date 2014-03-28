using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var f = new FileStream(@"c:\tree.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                var mas = new byte[10];

                int x = f.Read(mas, 0, 10);

                mas[2] = 0xAA;

                f.Seek(0, SeekOrigin.Begin);

                f.Write(mas, 0, 10);

                using(var reader = new BinaryReader(f))
                {
                    var n = reader.ReadInt32();
                    n = reader.ReadInt32();
                }

                var writer = new BinaryWriter(f);

                writer.Write(1);
                writer.Write(1);
                writer.Write(1);

                writer.Flush();
                writer.Close();
            }
        }
    }
}
