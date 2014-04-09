using System.Collections;
using System.Collections.Generic;

namespace _12_Enumerables
{
    internal class Library : IEnumerable, /*IEnumerator, */IEnumerator<Book>, IEnumerable<Book>
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
            return this;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public Book Current
        {
            get 
            {
                return _books[_index];
            }
        }

        public bool MoveNext()
        {
            if (_books.Count == 0 || _index + 1 == _books.Count)
            {
                _index = -1;
                return false;
            }
            else
            {
                _index++;
                return true;
            }
        }

        public void Reset()
        {
        }

        public void Dispose()
        {
        }

        public IEnumerable<object> Backwards 
        { 
            get
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    yield return _books[i];
                }
            }
        }
    }
}
