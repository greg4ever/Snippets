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
        void IA.fun1() // Explicit interface, private
        {
        }

        public int fun2()
        {
            return 1;
        }

        public void fun1() // Explicit interface, public
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
        public IEnumerator<T> GetEnumerator() // this one is public
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() // this one is private
        {
            return GetEnumerator();
        }
    }
}
