using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Snippets.Basics;
using System.Linq;

namespace SnippetsTest.Exo
{
    /*
       If a number n is not a prime, it can be factored into two factors a and b:
        n = a*b
       If both a and b were greater than the square root of n, a*b would be greater than n. 
     * So at least one of those factors must be less or equal to the square root of n, and to check if n is prime, 
     * we only need to test for factors less than or equal to the square root.
     * 0 & 1 are not prime nor composed (composed = factor of 2 prime numbers).
     * 2 is a prime number.
    */

    [TestFixture]
    class PrimeNumber
    {
        public static bool IsPrime(int n)
        {
            if (n == 0 || n == 1) return false;
            if (n == 2) return true;
            if (n%2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2) // faster than Math.Sqrt + i += 2
            {
                if (n%i == 0) return false;
            }

            return true;
        }

        public int[] GetNPrimeNumber(int n)
        {
            var ret = new int[n];
            var nbPrimes = 0;
            var i = 0;

            while (nbPrimes < n)
            {
                if (IsPrime(i))
                    ret[nbPrimes++] = i;

                i++;
            }

            return ret;
        }

        [Test]
        public void GetNPrime()
        {
            var primes = GetNPrimeNumber(100);
            Assert.AreEqual(541, primes[99]);
        }


        private bool[] MakeSieve(int n)
        {
            var sieve = Enumerable.Repeat(true, n).ToArray();

            for (int i = 2; i < n; ++i)
            {
                if (sieve[i])
                {
                    for (int j = i * 2; j < n; j += i)
                        sieve[j] = false;
                }
            }

            return sieve;
        }

        private int[] GetNPrimeNumberSieve(int n)
        {
            var sieve = MakeSieve(1000);
            var ret = new int[n];
            var nbPrimes = 0;
            var i = 0;

            while (nbPrimes < n)
            {
                if (sieve[i])
                    ret[nbPrimes++] = i;

                ++i;
            }

            return ret;
        }

        [Test]
        public void GetNPrimeSieve()
        {

            var primes = GetNPrimeNumber(100);
            Assert.AreEqual(541, primes[99]);
        }
    }
}
