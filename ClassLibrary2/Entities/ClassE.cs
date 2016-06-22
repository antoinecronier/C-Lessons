using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Table("ClassE")]
    public class ClassE : ClassD
    {
        public ClassE()
        {
            base.DoSomething();
            base.DoSomethingC();
            base.DoSomethingD();
        }
    }
}