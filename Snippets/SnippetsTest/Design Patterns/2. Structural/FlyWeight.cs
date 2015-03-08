using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._2._Structural.FlyWeight
{
    class Option { }

    class OptionFlyWeight
    {
        private readonly Dictionary<string, Option> _cache = new Dictionary<string, Option>();

        public OptionFlyWeight()
        {
            _cache.Add("Vanilla", new Option());
            _cache.Add("Barrier", new Option());
        }

        public Option GetOption(string id)
        {
            Option opt;
            if(_cache.TryGetValue(id, out opt))
                return opt;

            throw new ArgumentOutOfRangeException();
        }
    }
}
