using ReportLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;

            try
            {
                ReportPrinter.YearReport();
            }
            catch(ReportException)
            {
                Debug.WriteLine("X should be great than 0");
            }
            catch (FormatException ex)
            {
                Debug.WriteLine(string.Format("ERR: {0}", ex.Message));
                Debug.WriteLine(ex);
                //Console.WriteLine("ERROR");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEPTION: " + ex.Message);
            }
        }

        /// <summary>
        /// Print user reports
        /// </summary>
        /// <param name="x">Number of reports</param>
        private static void PrintReport(int x)
        {
            if (x > 0)
            {
                //print
            }
            else
            {
                throw new ReportException();
            }
        }
    }
}
