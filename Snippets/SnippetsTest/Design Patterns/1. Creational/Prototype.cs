using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._1._Creational
{
    // Prototype = implement Clone method

    public abstract class OptionPrototype
    {
        // normal implementation
        public abstract OptionPrototype Clone();
    }

    public class ConcretePrototype : OptionPrototype
    {
        public override OptionPrototype Clone()
        {
            return (OptionPrototype) MemberwiseClone(); // Clones the concrete class.
        }
    }
}
