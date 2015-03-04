 using System;
 using System.Collections;
 using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnippetsTest.Basics.Interface
{
    interface IA
    {
        void fun1();
    }

    interface IMyInterface : IA
    {
        new void fun1();
        int fun2();
    }

    class ConcreteClass : IMyInterface
    {
        void IA.fun1()
        {
        }

        public int fun2()
        {
            return 1;
        }

        void IMyInterface.fun1()
        {
        }
    }


    // Real life example
    interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }

    interface IEnumerable<T> : IEnumerable
    {
        new IEnumerator<T> GetEnumerator();
    }

    class MyClass<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
