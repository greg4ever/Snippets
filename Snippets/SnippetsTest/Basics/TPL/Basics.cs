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
        // Promise ~= Future
        // Future result is set by someone else
        // Promise result can be set by the user
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
