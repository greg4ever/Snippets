using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Basics
{
    // Only interfaces & delegates support variance

    // T: in = contravariance
    // R: out = covariance
    interface IMyVariance<in T, out R>
    {
        R MyFunction(T input);
    }

    class MyVariance<T, R> : IMyVariance<T, R>
    {
        public R MyFunction(T input)
        {
            return default(R);
        }
    }

    public delegate R MyDelegate<in T, out R>(T input);

    [TestFixture]
    public class Test
    {
        [Test]
        public void VarianceTest()
        {
            IMyVariance<ArgumentException, Exception> test = new MyVariance<Exception, ArgumentException>();

            MyDelegate<ArgumentException, Exception> MyDel = x => { return null; };
            MyDelegate<Exception, ArgumentException> MyDel2 = x => null;
            MyDel = MyDel2;
        }

        [Test]
        public void ArrayCovariance()
        {
            Exception[] array = new ArgumentException[10];
            array[0] = new Exception(); // raise ArrayTypeMismatchException, cause the backing store is type of ArgumentException
        }
        
        [Test]
        public void ListCovariance()
        {
            // List<Exception> list = new List<ArgumentException>(); list is not covariant
            // public interface IEnumerable<out T> : IEnumerable
            IEnumerable<Exception> ienum = new List<ArgumentException>(); // IEnumerable<T> is covariant
        }
    }
}
