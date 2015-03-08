using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._1._Creational
{
    class Singleton
    {
        private readonly Lazy<object> _instance = new Lazy<object>(() => new object());

        public object Instance
        {
            get { return _instance.Value; }
        }
    }
}
