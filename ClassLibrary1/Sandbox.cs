using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Sandbox
    {
        private ClassConcrete1 concrete1;
        private ClassAbstract1 cAbstract1;

        private ClassConcrete2 concrete2;
        private ClassAbstract2 cAbstract2;

        public Sandbox()
        {
            /*this.concrete = new ClassConcrete1();
            this.cAbstract = new ClassAbstract1();

            this.concrete.AbsField1 = 1;
            this.concrete.AbstractMethod1();*/

            concrete2 = new ClassConcrete2();
            concrete2.AbsMethod3();
            concrete2.AbsMethod1();
            concrete2.AbsMethod2();
        }
    }
}


