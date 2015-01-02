using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Diagnostics;

namespace SnippetsTest
{
    public class Msg : IDisposable
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public int D { get; set; }
        public int E { get; set; }
        public double[] F {get;set;}
        public double[] G { get; set; }

        public Msg()
        {
            F = new double[15];
            G = new double[15];
        }

        public void Dispose()
        {

        }

        public void Clear()
        {
            A = default(string);
            B = default(string);
            C = default(string);
            D = default(int);
            E = default(int);
            Array.Clear(F, 0, 15);
            Array.Clear(G, 0, 15);
        }
    }

    [TestClass]
    public class ToolboxTest
    {
        public int value;

        [TestMethod]
        public void TestMethod1()
        {
            var sw = new Stopwatch();
            sw.Start();

            int counter = 0;
            var tmp = new Msg();
            for (int i = 0; i < 100000; ++i)
            {
                //tmp.Clear();   
                counter += tmp.D;
            }

            sw.Stop();
            Assert.Fail("Elapsed time: " + sw.ElapsedTicks + " " + counter);
        }
    }
}
