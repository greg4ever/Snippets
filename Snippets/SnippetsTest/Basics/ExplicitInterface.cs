using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnippetsTest.Basics
{
    class TestInterface
    {
        static void Main()
        {
            SampleClass sc = new SampleClass();
            IControl ctrl = (IControl)sc;
            ISurface srfc = (ISurface)sc;

            // The following lines all call the same method.
            sc.Paint();
            ctrl.Paint();
            srfc.Paint();
        }
    }


    interface IControl
    {
        void Paint();
    }
    interface ISurface
    {
        void Paint();
    }
    class SampleClass : IControl, ISurface
    {
        // Both ISurface.Paint and IControl.Paint call this method.  
        public void Paint()
        {
            Console.WriteLine("Paint method in SampleClass");
        }
    }

    // Output: 
    // Paint method in SampleClass 
    // Paint method in SampleClass 
    // Paint method in SampleClass


    public class SampleClass2 : IControl, ISurface
    {
        void IControl.Paint()
        {
            System.Console.WriteLine("IControl.Paint");
        }
        void ISurface.Paint()
        {
            System.Console.WriteLine("ISurface.Paint");
        }
    }

    /*
        // Call the Paint methods from Main.

        SampleClass obj = new SampleClass();
        //obj.Paint();  // Compiler error.

        IControl c = (IControl)obj;
        c.Paint();  // Calls IControl.Paint on SampleClass.

        ISurface s = (ISurface)obj;
        s.Paint(); // Calls ISurface.Paint on SampleClass. 

        // Output: 
        // IControl.Paint 
        // ISurface.Paint
     */
}
