using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Basics.TPL
{
    [TestFixture]
    class Basics
    {
        [Test]
        // Future = Task<int>, result is set by the promise
        // Promise = delegate, set the result for the future
        public void RunFuture()
        {
            Task<int> future = Task.Factory.StartNew<int>(() =>
            {
                Thread.Sleep(2000);
                return 1;
            });

            var res = future.Result;
        }
    }
}
