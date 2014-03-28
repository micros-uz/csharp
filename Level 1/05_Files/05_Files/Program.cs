using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Files
{
    class Program
    {
        private const string FMT_Line = "{0, 8} | {3, 12} | {1} | {2}";
        static int count;
        static void Main(string[] args)
        {
            Console.Write("Enter Disk Name: ");

            string dir = Console.ReadLine();

            DirectoryInfo di = new DirectoryInfo(dir);

            if (di.Exists)
            {
                if (File.Exists("c:\\tree.txt"))
                    File.Delete("c:\\tree.txt");

                EnumDir(di);

                //var lines = File.ReadAllLines("c:\\tree.txt");
                //foreach (var item in lines)
                //    Console.WriteLine(item);
            }
            else
            {
                Console.WriteLine("Wrong dir name");
            }
        }

        private static void EnumDir(DirectoryInfo dir)
        {
            var dirs = GetDirs(dir);

            if (dirs != null)
            {
                foreach (var item in dirs)
                {
                    var st = string.Format(FMT_Line, count++,
                        "D", item.Name, string.Empty);

                    Print(st);
                    EnumDir(item);
                }

                foreach (FileInfo item in dir.EnumerateFiles())
                {
                    var st = string.Format(FMT_Line, count++,
                        "F", item.Name, item.Length);

                    Print(st);
                }
            }
        }

        private static void Print(string st)
        {
            Console.WriteLine(st);
            
            File.AppendAllLines("c:\\tree.txt", new String[] { st });
        }

        private static IEnumerable<DirectoryInfo> GetDirs(DirectoryInfo dir)
        {
            IEnumerable<DirectoryInfo> dirs = null;

            try
            {
                dirs = dir.EnumerateDirectories();
            }
            catch (Exception)
            {
            }

            return dirs;
        }
    }
}
