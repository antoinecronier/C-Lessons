using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Table("ClassD")]
    public class ClassD : ClassC
    {
        private int field5;

        [Column("Field5")]
        public int Field5
        {
            get { return field5; }
            set { field5 = value; }
        }

        public ClassD()
        {

        }

        public void DoSomethingD()
        {

        }
    }
}