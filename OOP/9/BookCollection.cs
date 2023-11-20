using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class BookCollection : IDictionary<string, Book>
    {
        private List<Book> books;

        public BookCollection()
        {
            books = new List<Book>();
        }

        public void Add(string key, Book value)
        {
            books.Add(value);
        }

        public bool Remove(string key)
        {
            return false;
        }

        public bool ContainsKey(string key)
        {
            return books.Exists(book => book.Title == key);
        }


        public bool TryGetValue(string key, out Book value)
        {
            value = books.Find(book => book.Title == key);
            return value != null;
        }


        public ICollection<Book> Values
        {
            get { return books; }
        }


        public int Count
        {
            get { return books.Count; }
        }


        public bool IsReadOnly
        {
            get { return true; }
        }

        public ICollection<string> Keys => throw new NotImplementedException();

        public Book this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public IEnumerator<KeyValuePair<string, Book>> GetEnumerator()
        {
            foreach (var book in books)
            {
                yield return new KeyValuePair<string, Book>(book.Title, book);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<string, Book> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, Book> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, Book>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, Book> item)
        {
            throw new NotImplementedException();
        }
    }
}
