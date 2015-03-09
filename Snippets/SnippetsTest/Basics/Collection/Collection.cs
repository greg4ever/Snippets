using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Snippets.Basics;

namespace SnippetsTest.Basics.DataStructure
{
    [TestFixture]
    class Test
    {
        /*
         * Non associative collections
         */
        public void List() // backed as an array
        {
            var list = new List<int>();
            list.Add(1);
            list.RemoveAt(0);
            list.BinarySearch(0, Comparer<int>.Default); // list must be sorted/ dichotomy O(log n)
        }

        public void LinkedList()
        {
            var list = new LinkedList<int>();
            var node = list.AddFirst(1);
            list.AddAfter(node, 2);
            list.Remove(node);
        }

        public void Queue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            var head = queue.Peek();
            head = queue.Dequeue();
        }

        public void Stack()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            var head = stack.Peek();
            head = stack.Pop();
        }

        public void Hashset() // undordered
        {
            var set = new HashSet<int>();
            set.Add(1);
            set.Remove(1);
        }

        public void SortedSet() // Backed as a Binary Search Tree, ordered
        {
            var set = new SortedSet<int>();
            set.Add(1);
            set.Contains(1);
            set.Remove(1);
        }


        /*
         * Associative collections
         */

        [Test]
        public void Dictionary() // unordered
        {
            var dico = new Dictionary<int, int>();
            dico[1] = 1;
            int res;
            dico.TryGetValue(1, out res);
            dico.Add(1, 2); // Exception: This key already exists
            dico[1] = 2; // override value
        }

        // insertion O(n)
        // backed as an ordered list
        // array indexing is faster than following tree node, efficient if we load all the data upfront
        public void SortedList()
        {
            var sList = new SortedList<int, int>();
            sList[1] = 1;
            sList.Add(2, 2);
            int res;
            sList.TryGetValue(1, out res);
        }

        public void SortedDictionary() // backed a a binary search tree, ordered
        {
            var sDico = new SortedDictionary<int, int>();
            sDico[1] = 1;
            sDico.Add(1, 1);
            int res;
            sDico.TryGetValue(1, out res);
        }
    }
}
