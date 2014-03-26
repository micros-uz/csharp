using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLib
{
    public static class ReportPrinter
    {
        public static void YearReport()
        {
            var ex = new ReportException();

            try
            {
                throw ex;

                Debug.WriteLine("TRY");
            }
            catch(FormatException)
            {
                Debug.WriteLine("CATCH");
            }
            finally
            {
                Debug.WriteLine("FINALLY");
            }

            Debug.WriteLine("AFTER FINALLY");
        }
    }
}
