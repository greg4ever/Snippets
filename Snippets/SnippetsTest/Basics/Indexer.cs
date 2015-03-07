using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Basics.Indexer
{
    class Indexer
    {
        private List<int> _list = new List<int>(); 

        public int this[int a, int b, int c]
        {
            get { return _list[a + b + c]; }
            set { ; }
        }
    }

    [TestFixture]
    class Test
    {
        [Test]
        public void Run()
        {
            var v = new Indexer();
            var tmp = v[1, 2, 3];
        }
    }
}
