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

        public override void AbsMethod2()
        {
            //base.AbsMethod2();
            Debug.WriteLine("AbsMethod2 override");
        }

        public override void AbsMethod3()
        {
            Debug.WriteLine("AbsMethod3 override");
        }

        public delegate void Del();

        public void AbsMethod4()
        {
            Del handler = base.AbsMethod2;
            handler();

            Del handler1 = delegate ()
            {
                handler();
                Debug.WriteLine("handler1 in concrete");
            };

            handler1();

            //New stuff to do
            Debug.WriteLine("AbsMethod2 in concrete");
        }
    }
}