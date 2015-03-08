using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnippetsTest.Basics
{
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

    public class Test
    {
        public void VarianceTest()
        {
            IMyVariance<ArgumentException, Exception> test = new MyVariance<Exception, ArgumentException>();

            MyDelegate<ArgumentException, Exception> MyDel = x => { return null; };
            MyDelegate<Exception, ArgumentException> MyDel2 = x => null;
            MyDel = MyDel2;
        }
    }
}
