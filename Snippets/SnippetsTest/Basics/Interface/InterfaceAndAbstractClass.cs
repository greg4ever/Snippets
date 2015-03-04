﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnippetsTest.Basics
{
    interface IMyInterface
    {
        void fun1();
        int fun2();
    }

    // If an abstract class implements an interface, you must declare the function (abstract)
    abstract class MyClass : IMyInterface
    {
        public abstract void fun1();

        public int fun2()
        {
            return 0;
        }
    }

    class ConcreteClass : MyClass
    {
        public override void fun1()
        {
        }
    }
}
