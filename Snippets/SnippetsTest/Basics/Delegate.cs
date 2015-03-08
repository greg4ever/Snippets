using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using NUnit.Framework;

namespace SnippetsTest.Basics
{
    [TestFixture]
    public class DelegateFun
    {
        public delegate int MyDelegate(int x);

        public static int MyFunction(int x)
        {
            return x + 1;
        }

        [Test]
        public void OldStyleDelegate()
        {
            MyDelegate del1 = new MyDelegate(MyFunction);
            MyDelegate del2 = MyFunction; // c# 2

            var res = del1(30);
            Assert.AreEqual(31, res);
        }

        [Test]
        public void OldStyleDelegateInvoke()
        {
            var del1 = new MyDelegate(MyFunction);
            var res = del1.Invoke(30);
            Assert.AreEqual(31, res);
        }

        /*
            Do you mean Delegate.Invoke/BeginInvoke or Control.Invoke/BeginInvoke?

            Delegate.Invoke: Executes synchronously, on the same thread.
            Delegate.BeginInvoke: Executes asynchronously, on a threadpool thread.
            Control.Invoke: Executes on the UI thread, but calling thread waits for completion before continuing.
            Control.BeginInvoke: Executes on the UI thread, and calling thread doesn't wait for completion.
        */

        [Test]
        public void OldStyleDelegateBeginInvokeEndInvoke()
        {
            var del1 = new MyDelegate(MyFunction);
            var asyncRes = del1.BeginInvoke(30, null, null);

            var res = del1.EndInvoke(asyncRes);
            Assert.AreEqual(31, res);
        }

        [Test]
        public void OldStyleDelegateBeginInvokeWaitHandle()
        {
            var del1 = new MyDelegate(MyFunction);
            var asyncRes = del1.BeginInvoke(30, null, null);

            asyncRes.AsyncWaitHandle.WaitOne();
            var res = del1.EndInvoke(asyncRes);
            Assert.AreEqual(31, res);
        }
        
        [Test]
        public void OldStyleDelegateBeginInvokeCallback()
        {
            ManualResetEvent mre1 = new ManualResetEvent(false);
            int res = 0;
            var del1 = new MyDelegate(MyFunction);
            var asyncRes = del1.BeginInvoke(30, x => { res = del1.EndInvoke(x); mre1.Set(); }, null);

            mre1.WaitOne();
            Assert.AreEqual(31, res);
        }

        [Test]
        public void OldStyleDelegateBeginInvokePoll()
        {
            var del1 = new MyDelegate(MyFunction);
            var asyncRes = del1.BeginInvoke(30, null, null);

            while(!asyncRes.IsCompleted)
                Thread.Sleep(10);

            int res = del1.EndInvoke(asyncRes);
            Assert.AreEqual(31, res);
        }
   
        [Test]
        public void AnonymousDelegate()
        {
            MyDelegate del1 = delegate(int x)
            {
                return x + 1;
            };

            var res = del1(30);
            Assert.AreEqual(31, res);
        }

        [Test]
        public void IgnoreParameterDelegate()
        {
            MyDelegate del1 = delegate { return 0; };
            // MyDelegate del2 = () => { return 0; }; // KO, anonymous delegate can be useful in this case
        }

        [Test]
        public void MultiDelegate() // delegate are immutable
        {
            MyDelegate del1 = new MyDelegate(MyFunction);
            del1 += new MyDelegate(MyFunction);
            del1 = (MyDelegate)Delegate.Combine(del1, new MyDelegate(MyFunction));

            Assert.AreEqual(3, del1.GetInvocationList().Length);
        }

        [Test]
        public void LambdaExpression()
        {
            MyDelegate del1 = x => x + 1;
            MyDelegate del2 = (int x) => x + 1; // can be typed
            MyDelegate del3 = x => { return x + 1; };

            var res = del1(30);
            Assert.AreEqual(31, res);
        }

        // Contravariance / Covariance 

        delegate void MyDelegate2(ArgumentException o);
        void MyMethod2(Exception list) { }
        [Test]
        public void ParameterTypeContravariance() // c# 2
        {
            MyDelegate2 del1 = MyMethod2; // ArgumentException can match the Exception type
        }

        [Test]
        public void ContravarianceDoesNOTApplyToAnonymousMethod()
        {
            MyDelegate2 del1 = (ArgumentException e) => { ;}; // OK
            //MyDelegate2 del2 = (Exception e) => { ;}; // KO
        }

        delegate Exception MyDelegate3();
        ArgumentException MyMethod3() { return null;  }
        [Test]
        public void ReturnTypeCovariance()
        {
            MyDelegate3 del1 = MyMethod3;
        }
    }
}
