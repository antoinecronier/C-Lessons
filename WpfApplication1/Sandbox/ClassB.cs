using System;

namespace ClassLibrary1
{
    public class ClassB : ClassA, IDo3, IDo1, IDo2
    {
        private int field1;

        public int Field1
        {
            get
            {
                return this.field1;
            }

            set
            {
                this.field1 = value;
            }
        }

        public ClassB()
        {
            base.Field1 = this.field1;
            base.Field2 = 2;
            base.DoSomething();
        }

        public void Do()
        {
            throw new NotImplementedException();
        }

        public void DoOtherStuff()
        {
            throw new System.NotImplementedException();
        }

        public void Shake()
        {
            throw new NotImplementedException();
        }

        public void Try()
        {
            throw new NotImplementedException();
        }
    }
}