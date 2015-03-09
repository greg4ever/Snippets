using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Basics.ConcurrentCollection
{
    [TestFixture]
    class ConcurrentCollection
    {
        public void ConcurrentQueue() // backed as a lock-free linked list
        {
            var queue = new ConcurrentQueue<int>();
        }

        public void ConcurrentStack()
        {
            var stack = new ConcurrentStack<int>();
        }

        public void ConcurrentDictionary()
        {
            var dico = new ConcurrentDictionary<int, int>();
        }

        [Test]
        public void ConcurrentBag() // = multiset: unordered collection that allows duplicates
        {
            var bag = new ConcurrentBag<int>();
            bag.Add(1);
            bag.Add(1);
            int res;
            Assert.IsTrue(bag.TryPeek(out res));
            Assert.IsTrue(bag.TryTake(out res));
            Assert.IsTrue(bag.TryTake(out res));
            Assert.IsFalse(bag.TryTake(out res));
        }
    }
}
