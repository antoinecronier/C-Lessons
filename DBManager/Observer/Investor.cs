using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Observer
{
    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    public interface IInvestor
    {
        void Update(Object toSee);
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    public class Investor : IInvestor
    {
        private string _name;
        private Object _toSee;

        // Constructor
        public Investor(string name)
        {
            this._name = name;
        }

        public void Update(Object toSee)
        {
        }

        // Gets or sets the stock
        public Object toSee
        {
            get { return _toSee; }
            set { _toSee = value; }
        }
    }
}
