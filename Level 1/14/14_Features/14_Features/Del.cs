using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Features
{
    interface Del<T>
    {
        void Work(T obj);
    }

    delegate void Del2<T>(T obj);

    class DelImpl<T> : Del<T>
    {
        public void Work(T obj)
        {            
        }
    }
}
