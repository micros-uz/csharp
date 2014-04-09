using System;
using System.Collections.Generic;

namespace _13_LINQ_
{
    public static class Extensions
    {
        public static void Perform<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static void Perform<T>(this IEnumerable<T> list, Func<T, bool> func)
        {
            foreach (var item in list)
            {
                if (func(item))
                    break;
            }
        }

        public static int Sum<T>(this IEnumerable<T> list, Func<T, int> func)
        {
            var res = 0;
            foreach (var item in list)
            {
                res += func(item);
            }

            return res;
        }
    }
}
