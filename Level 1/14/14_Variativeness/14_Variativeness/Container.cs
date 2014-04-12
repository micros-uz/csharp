using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Variativeness
{
    public class Container<T> : IContainer<T>
    {
        public T GetItem()
        {
            return default(T);
        }
    }

    public class Container2<T> : IContainer2<T>
    {
        public void SetItem(T obj)
        {
        }
    }
}
