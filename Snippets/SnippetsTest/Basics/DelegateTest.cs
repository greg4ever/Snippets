using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace SnippetsTest.Basics
{
    [TestClass]
    public class DelegateTest
    {
        public delegate int MyDelegate(int x);

        public static int MyFunction(int x)
        {
            return x + 1;
        }

        [TestMethod]
        public void OldStyleDelegate()
        {
            MyDelegate del1 = new MyDelegate(MyFunction);
            MyDelegate del2 = MyFunction; // c# 2

            var res = del1(30);
            Assert.AreEqual(31, res);
        }

        [TestMethod]
        public void OldStyleDelegateInvoke()
        {
            var del1 = new MyDelegate(MyFunction);
            var res = del1.Invoke(30);
            Assert.AreEqual(31, res);
        }

        [TestMethod]
        public void OldStyleDelegateBeginInvokeEndInvoke()
        {
            var del1 = new MyDelegate(MyFunction);
            var asyncRes = del1.BeginInvoke(30, null, null);

            var res = del1.EndInvoke(asyncRes);
            Assert.AreEqual(31, res);
        }

        [TestMethod]
        public void OldStyleDelegateBeginInvokeWaitHandle()
        {
            var del1 = new MyDelegate(MyFunction);
            var asyncRes = del1.BeginInvoke(30, null, null);

            asyncRes.AsyncWaitHandle.WaitOne();
            var res = del1.EndInvoke(asyncRes);
            Assert.AreEqual(31, res);
        }
        
        [TestMethod]
        public void OldStyleDelegateBeginInvokeCallback()
        {
            ManualResetEvent mre1 = new ManualResetEvent(false);
            int res = 0;
            var del1 = new MyDelegate(MyFunction);
            var asyncRes = del1.BeginInvoke(30, x => { res = del1.EndInvoke(x); mre1.Set(); }, null);

            mre1.WaitOne();
            Assert.AreEqual(31, res);
        }

        [TestMethod]
        public void OldStyleDelegateBeginInvokePoll()
        {
            var del1 = new MyDelegate(MyFunction);
            var asyncRes = del1.BeginInvoke(30, null, null);

            while(!asyncRes.IsCompleted)
                Thread.Sleep(10);

            int res = del1.EndInvoke(asyncRes);
            Assert.AreEqual(31, res);
        }
   
        [TestMethod]
        public void AnonymousDelegate()
        {
            MyDelegate del1 = delegate(int x)
            {
                return x + 1;
            };

            var res = del1(30);
            Assert.AreEqual(31, res);
        }

        [TestMethod]
        public void IgnoreParameterDelegate()
        {
            MyDelegate del1 = delegate { return 0; };
            // MyDelegate del2 = () => { return 0; }; // KO
        }

        [TestMethod]
        public void MultiDelegate()
        {
            MyDelegate del1 = new MyDelegate(MyFunction);
            del1 += new MyDelegate(MyFunction);
            del1 = (MyDelegate)Delegate.Combine(del1, new MyDelegate(MyFunction));

            Assert.AreEqual(3, del1.GetInvocationList().Length);
        }

        [TestMethod]
        public void LambdaExpression()
        {
            MyDelegate del1 = x => x + 1;
            MyDelegate del2 = (int x) => x + 1; // can be typed
            MyDelegate del3 = x => { return x + 1; };

            var res = del1(30);
            Assert.AreEqual(31, res);
        }

        delegate void MyDelegate2(ArgumentException o);
        void MyMethod2(Exception list) { }
        [TestMethod]
        public void ParameterTypeContravariance() // c# 2
        {
            MyDelegate2 del1 = MyMethod2; // ArgumentException can match the Exception type
        }

        [TestMethod]
        public void ContravarianceDoesNOTApplyToAnonymousMethod()
        {
            MyDelegate2 del1 = (ArgumentException e) => { ;}; // OK
            //MyDelegate2 del2 = (Exception e) => { ;}; // KO
        }

        delegate Exception MyDelegate3();
        ArgumentException MyMethod3() { return null;  }
        [TestMethod]
        public void ReturnTypeCovariance()
        {
            MyDelegate3 del1 = MyMethod3;
        }
    }
}
