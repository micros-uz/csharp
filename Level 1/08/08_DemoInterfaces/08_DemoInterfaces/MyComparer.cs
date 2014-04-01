using System;
using System.Collections;

namespace _08_DemoInterfaces
{
    internal class MyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var dt1 = x.ToString();
            var dt2 = y.ToString();

            var y1 = Convert.ToInt32(dt1.Substring(4, 4));
            var y2 = Convert.ToInt32(dt2.Substring(4, 4));

            if (y1 < y2) return -1;
            if (y1 > y2) return 1;

            var m1 = Convert.ToInt32(dt1.Substring(2, 2));
            var m2 = Convert.ToInt32(dt2.Substring(2, 2));

            if (m1 < m2) return -1;
            if (m1 > m2) return 1;

            var d1 = Convert.ToInt32(dt1.Substring(0, 2));
            var d2 = Convert.ToInt32(dt2.Substring(0, 2));

            if (d1 < d2) return -1;
            if (d1 > d2) return 1;

            return 0;
        }
    }
}
