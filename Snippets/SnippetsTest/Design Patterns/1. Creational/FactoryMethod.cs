using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._1._Creational
{
    interface IOption
    {
        void Price();
    }

    class Option : IOption
    {
        public void Price()
        {
        }
    }

    class BarrierOption : IOption
    {
        public void Price()
        {
        }
    }

    class Factory
    {
        public IOption GetOption(string type)
        {
            switch(type)
            {
                case "O":
                    return new Option();
                case "OB":
                    return new BarrierOption();
            }

            throw new ArgumentOutOfRangeException(type);
        }
    }
}
