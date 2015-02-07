using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnippetsTest.Exo
{
    [TestClass]
    public class Permutation
    {
        [TestMethod]
        public void Run()
        {
            var permutations = GetPermutations(5, new[] { 2, 3, 5, 6, 7, 9 });
            var res = permutations.Count;
        }

        // Get the unique 3-digits permutations divisable by 5
        private static List<int> GetPermutations(int divisor, params int[] ints)
        {
            if (ints.Length < 3)
                throw new ArgumentOutOfRangeException("Array size must be > 2");

            var res = new HashSet<int>();

            for (int i = 0; i < ints.Length; ++i)
                for (int j = 0; j < ints.Length; ++j)
                    for (int k = 0; k < ints.Length; ++k)
                    {
                        if (i == j
                            || j == k
                            || i == k)
                            continue;

                        var n = GetAsNumber(ints[i], ints[j], ints[k]);
                        if (n % 5 == 0)
                            res.Add(n);
                    }

            return res.ToList();
        }

        private static int GetAsNumber(int a, int b, int c)
        {
            return a * 100 + b * 10 + c;
        }
    }
}
