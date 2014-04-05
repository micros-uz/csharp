using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_CustomCollection
{
    class PrintableList<T>
    {
        //private List<T> list = new List<T>();
        private const int CAPACITY = 10;
        private int _capacity;
        private int _total;
        private T[] list;
        private int _index;


        public PrintableList()
            : this(CAPACITY)
        {

        }

        public PrintableList(int capacity = CAPACITY)
        {
            _capacity = capacity;
            _total = _capacity;
            list = new T[_capacity];
        }

        public void Add(T val)
        {
            if (_index == _total)
            {
                _total += _capacity;
                var tmp = new T[_total];
                Array.Copy(list, tmp, _index);
                list = tmp;
            }

            list[_index++] = val;
            //list.Add(val);
        }

        public void Display()
        {
            for (var k = 0; k < _index; k++ )
            {
                Console.WriteLine(list[k]);
            }
        }
    }
}
