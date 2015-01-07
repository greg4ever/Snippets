using System;
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
}
