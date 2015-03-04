using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Exo
{
    [TestFixture]
    public class Permutation
    {
        //[Test]
        public void Run()
        {
            var permutations = GetPermutations(5, new[] { 2, 3, 5, 6, 7, 9 });
            var res = permutations.Count;
        }

        [Test]
        // 2 3 4
        // 2 4 3
        // 3 2 4
        // 3 4 2
        // 4 2 3
        // 4 3 2
        public void RunHeapAlgo()
        {
            var permutations = HeapAlgoIter(new List<int> { 2, 3, 4 }, 3);
        }

        private static void swap(List<int> v, int i, int j)
        {
            int t = v[i]; v[i] = v[j]; v[j] = t;
        }

        private static List<List<int>> HeapAlgoIter(List<int> ints, int n)
        {
            var res = new List<List<int>>();
            var idx = new int[n];

            res.Add(ints.ToList());

            for (int i = 1; i < n; )
            {
                if (idx[i] < i)
                {
                    int swapIdx = i % 2 * idx[i];
                    swap(ints, i % 2 == 1 ? 0 : swapIdx, i);
                    res.Add(ints.ToList());
                    idx[i]++;
                    i = 1;                    
                }
                else
                { 
                    idx[i] = 0;
                    i++;
                }
            }

            return res;
        }

        static List<List<int>> HeapAlgoRecu(List<int> ints, int n)
        {
            var res = new List<List<int>>();
            if (n == 1)
            {
                res.Add(ints.ToList());
                return res;
            }

            for (int i = 0; i < n; i++)
            {
                res.AddRange(HeapAlgoRecu(ints, n - 1));
                swap(ints, n % 2 == 1 ? 0 : i, n - 1);
            }

            return res;

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
