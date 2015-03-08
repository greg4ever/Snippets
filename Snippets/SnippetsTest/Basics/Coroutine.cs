using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Basics.Coroutine
{
    public class MyClass
    {
        public IEnumerable<int> GetEnumerable1()
        {
            // Generate a state machine behind
            yield return 1;
            yield return 3;
        }

        public IEnumerable<int>GetEnumerable2()
        {
            yield return 1;
            yield return 3;
            yield break;
            yield return 5;
        }
    }

    [TestFixture]
    class CoroutineTest
    {
        [Test]
        public void Test1()
        {
            var sum = new MyClass().GetEnumerable1().Sum();
            Assert.AreEqual(4, sum);

            sum = new MyClass().GetEnumerable2().Sum();
            Assert.AreEqual(4, sum);
        }
    }
}
