using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class ClassConcrete1 : ClassAbstract1
    {
    }

    public class ClassConcrete2 : ClassAbstract2
    {
        public new void AbsMethod1()
        {
            Debug.WriteLine("AbsMethod1 override");
        }

        public override void AbsMethod3()
        {
            Debug.WriteLine("AbsMethod3 override");
        }
    }
}