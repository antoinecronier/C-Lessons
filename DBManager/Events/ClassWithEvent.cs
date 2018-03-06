using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Events
{
    //public delegate void EventHandler(object sender, EventArgs e);
    public class ClassWithEvent
    {
        #region Events
        public event ChangedEventHandler Changed;
        public event EventHandler Handler;
        public event EventHandler<ClassA> CustomClassAEvent;
        public event EventHandler<CustomEventArgs> CustomEventArg;
        public event UnhandledExceptionEventHandler UnHandle;
        public ListWithChangedEvent EventList;
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
            Handler?.Invoke(this, e);
        }

        public virtual void OnCustomClassAEvent(ClassA e)
        {
            if (CustomClassAEvent != null)
                CustomClassAEvent(this, e);
        }

        public virtual void OnCustomEventArg(CustomEventArgs e)
        {
            if (CustomEventArg != null)
            {
                e.Logger.Log(e.Message);
                CustomEventArg(this, e);
            }
                
        }
        #endregion

        public ClassWithEvent()
        {
            EventList = new ListWithChangedEvent();
        }

        #region Methods
        #endregion
    }
}
