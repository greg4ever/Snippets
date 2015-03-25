using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Exo
{
    [TestFixture]
    class Fibo
    {
        [Test]
        public void FiboSeriesIter()
        {
            Func<int, int[]> func = n =>
            {
                if (n == 0 || n == 1) return new [] { n };

                var fibos = new int[n + 1];
                fibos[0] = 0;
                fibos[1] = 1;

                for (int i = 2; i <= n; ++i)
                {
                    fibos[i] = fibos[i - 1] + fibos[i - 2];
                }

                return fibos;
            };

            var res = func(15);
            Assert.AreEqual(377, res[14]);
        }

        [Test]
        public void FiboSeriesRecursive()
        {
            Func<int, List<int>> func = null;
            func = n =>
            {
                if (n == 0 || n == 1) return new List<int>{ n };
                if (n == 2) return new List<int> { 0, 1 };

                var fibo_n1 = func(n - 1);
                var fibos = new List<int>(fibo_n1);
                fibos.Add(fibos[fibos.Count - 1] + fibos[fibos.Count - 2]);

                return fibos;
            };

            var res = func(15);
            Assert.AreEqual(377, res[14]);
        }

        [Test]
        public void FiboNumberIter()
        {
            Func<int, int> func = n =>
            {
                if (n == 0 || n == 1) return n;

                var a = 0;
                var b = 1;

                for (int i = 2; i <= n; ++i)
                {
                    var fibo = a + b;
                    a = b;
                    b = fibo;
                }

                return b;
            };

            Assert.AreEqual(377, func(14));
        }

        [Test]
        public void FiboNumberRecursive()
        {
            Func<int, int> func = null;
            func = n =>
            {
                if (n == 0 || n == 1) return n;
                return func(n - 1) + func(n - 2);
            };

            Assert.AreEqual(377, func(14));
        }
    }
}
