using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Basics
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public async void Run()
        {
            bool value = false;
            var task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                value = true;
            });
            await task;

            Assert.IsTrue(value);
        }
    }
}
