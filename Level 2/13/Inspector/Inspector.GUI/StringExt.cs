using System;

namespace Inspector.GUI
{
    internal static class StringExt
    {
        public static decimal D(this string val)
        {
            return Convert.ToDecimal(val);
        }
    }
}
