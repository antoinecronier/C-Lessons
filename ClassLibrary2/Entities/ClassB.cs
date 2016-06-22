using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1
{
    [Table("ClassB")]
    public class ClassB : ClassA, IDo3, IDo1, IDo2
    {
        private int field1;

        [Column("Field1")]
        public new int Field1
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
            base.Field2 = "field2";
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