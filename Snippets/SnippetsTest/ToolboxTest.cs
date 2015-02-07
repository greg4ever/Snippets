using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Diagnostics;

namespace SnippetsTest
{
    interface IMyInterface
    {
        void fun1();
        int fun2();
    }
    abstract class MyClass : IMyInterface
    {
        public abstract void fun1();

        public int fun2()
        { return 0; }
    }

    class AAA : MyClass
    {
        public override void fun1()
        {
        }
    }

    [TestClass]
    public class ToolBoxTest
    {
        public static void Main(string[] args)
        {
        }

    }
}
