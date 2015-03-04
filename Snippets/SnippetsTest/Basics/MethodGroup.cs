using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnippetsTest.Basics.MethodGroup
{
    class Utils
    {
        public static void Test(int a) { }
        public static void Test(double a) { }
        public static void Test(string a) { }
    }

    public class MyClass
    {
        public void Run(Action<string> param) { }
    }

    public class Test
    {
        public void Run()
        {
            new MyClass().Run(Utils.Test);
        }
    }
}
