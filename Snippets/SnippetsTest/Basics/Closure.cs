using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Basics
{
    [TestFixture]
    class Closure
    {
        [Test]
        public void Run()
        {
            // Display 0, 1, 2, ... in C# 5 but 10, 10, 10, ... in C# 4
            // See C# cheatsheet for more details
            var actions = new List<Action>();
            foreach (var i in Enumerable.Range(0, 10))
                actions.Add(() => Console.Write(i + " "));

            foreach (var act in actions) act();

            Console.WriteLine();

            // Display 10, 10, 10, ... - because not using foreach
            actions = new List<Action>();
            for (var i = 0; i < 10; i++)
                actions.Add(() => Console.Write(i  + " "));

            foreach (var act in actions) act();
        }
    }
}
