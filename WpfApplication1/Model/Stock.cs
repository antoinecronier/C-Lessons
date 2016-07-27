using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class Stock
    {
        public const double UP = 0.7;
        public const double DOWN = 1.4;

        public event EventHandler Handler;

        private int number;

        public int Number
        {
            get { return number; }
            set { number = value;
                this.OnHandler(new EventArgs());
            }
        }

        public virtual void OnHandler(EventArgs e)
        {
            if (Handler != null)
                Handler(this, e);
        }
    }
}
