using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._2._Structural.FlyWeight
{
    class Option
    {
        
    }

    class OptionFlyWeight
    {
        private readonly Dictionary<string, Option> _cache = new Dictionary<string, Option>();

        public Option GetOption(string id)
        {
            Option opt;
            if(!_cache.TryGetValue(id, out opt))
            {
                opt = new Option();
                _cache[id] = opt;
            }

            return opt;
        }
    }
}
