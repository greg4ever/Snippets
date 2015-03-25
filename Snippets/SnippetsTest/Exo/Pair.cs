using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Exo
{
    /*
     * Given N unique positive integers, we want to count the total pairs of numbers whose
       difference is K. The solution should minimize computational time complexity to the best
       of your ability
     */
    [TestFixture]
    class Pair
    {
        static int GetNBPairEqual(List<int> numbers, int K)
        {
            int ret = 0;
            var hashset = new HashSet<int>();

            for (var i = 0; i < numbers.Count; ++i)
            {
                if (hashset.Contains(numbers[i] - K))
                    ++ret;

                if (hashset.Contains(numbers[i] + K))
                    ++ret;

                hashset.Add(numbers[i]);
            }

            return ret;
        }

        [Test]
        public void Run()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            Assert.AreEqual(3, GetNBPairEqual(list, 2));
        }
    }
}
