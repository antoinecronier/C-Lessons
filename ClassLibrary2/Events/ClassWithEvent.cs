using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Events
{
    public delegate void EventHandler(object sender, EventArgs e);
    public class ClassWithEvent
    {
        #region Events
        public event ChangedEventHandler Changed;
        public event EventHandler Handler;
        public event EventHandler<ClassA> CustomClassAEvent;
        #endregion

        #region Events Methods
        // Invoke the Changed event; called whenever list changes
        public virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public virtual void OnHandler(EventArgs e)
        {
            if (Handler != null)
                Handler(this, e);
        }

        public virtual void OnCustomClassAEvent(ClassA e)
        {
            if (CustomClassAEvent != null)
                CustomClassAEvent(this, e);
        }
        #endregion

        #region Methods
        #endregion
    }
}
