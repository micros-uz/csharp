using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Enumerables
{
    internal class Library2 : IEnumerable, IEnumerable<Book>
    {
        private List<Book> _books = new List<Book>();
        private int _index = -1;

        internal void Add(Book book)
        {
            _books.Add(book);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                yield return _books[i];
            }
        }

        public IEnumerable<object> Backwards
        {
            get
            {
                for (int i = _books.Count - 1; i >= 0; i--)
                {
                    yield return _books[i];
                }
            }
        }
    }
}
