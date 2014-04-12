using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Variativeness
{
    public interface IContainer<out T>
    {
        T GetItem();
    }

    public interface IContainer2<in T>
    {
        void SetItem(T obj);
    }
}
