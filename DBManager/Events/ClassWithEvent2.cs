using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Events
{
    public class ClassWithEvent2
    {
        public event EventHandler Handler;
        public event EventHandler<ClassWithEvent2> Handler1;

        public int Id { get; set; }
        public String Name { get; set; }

        public virtual void OnHandler(EventArgs e)
        {
            if (Handler != null)
                Handler(this, e);
        }

        public virtual void OnHandler1(ClassWithEvent2 e)
        {
            if (Handler1 != null)
                Handler1(this, e);
        }
    }
}
