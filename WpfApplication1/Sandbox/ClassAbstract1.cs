using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public abstract class ClassAbstract1
    {
        private int absField1;
        private int absField2;

        public int AbsField1
        {
            get
            {
                return this.absField1;
            }

            set
            {
                this.absField1 = value;
            }
        }

        public int AbsField2
        {
            get
            {
                return this.absField2;
            }

            set
            {
                this.absField2 = value;
            }
        }

        public void AbstractMethod1()
        {
            throw new System.NotImplementedException();
        }

        public void AbstractMethod2()
        {
            throw new System.NotImplementedException();
        }
    }

    public abstract class ClassAbstract2
    {
        private int absField1;
        private int absField2;

        public int AbsField1
        {
            get
            {
                return this.absField1;
            }

            set
            {
                this.absField1 = value;
            }
        }

        public int AbsField2
        {
            get
            {
                return this.absField2;
            }

            set
            {
                this.absField2 = value;
            }
        }

        public void AbsMethod1()
        {
            Debug.WriteLine("AbsMethod1 base");
        }


        public void AbsMethod2()
        {
            Debug.WriteLine("AbsMethod2 base");
        }

        public abstract void AbsMethod3();


    }
}