using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Collections;
using NUnit.Framework;

namespace SnippetsTest.Basics
{
    public class CustomCollection<T> : IEnumerable<T>
    {
        private List<T> _list = new List<T>();

        public void Add(T item)
        {
            _list.Add(item);
        }
        
        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _list)
                yield return item;
        }
    }


    [TestFixture]
    public class CollectionTest
    {
        [Test]
        public void CollectionInitializer()
        {
            var g = new CustomCollection<int>() { 1, 2, 3 };
        }
    }
}
