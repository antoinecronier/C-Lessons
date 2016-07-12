using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Events
{
    public class CustomEventArgs : EventArgs
    {
        private object currentClass;

        public object CurrentClass
        {
            get { return currentClass; }
            set { currentClass = value; }
        }

        private String message;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        private Logger logger;

        public Logger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

    }
}
