using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Basics.Await
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public async Task<int> Run() // C# 5 - The return type with async must be void, Task or Task<T>
        {
            bool value = false;
            var task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                value = true;
            });
            await task;

            Assert.IsTrue(value);
            return 0;
        }

        [Test]
        public void Run1() // Is similar to Run() but in C# 4
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            var currentScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            bool value = false;
            var task = Task.Factory.StartNew(() => Thread.Sleep(5000)).ContinueWith((x) => value = true, currentScheduler);
            task.Wait();

            Assert.IsTrue(value);
        }
    }
}
