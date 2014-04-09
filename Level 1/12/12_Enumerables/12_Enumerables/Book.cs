using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Enumerables
{
    internal class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Title, Year);
        }
    }
}
