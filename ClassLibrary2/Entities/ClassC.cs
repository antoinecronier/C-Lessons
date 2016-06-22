using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Table("ClassC")]
    public class ClassC : ClassB
    {
        private int field4;

        [Column("Field4")]
        public int Field4
        {
            get { return field4; }
            set { field4 = value; }
        }

        public void DoSomethingC()
        {

        }
    }
}