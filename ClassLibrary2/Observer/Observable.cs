using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Observer
{
    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    public abstract class Observable
    {
        private List<IInvestor> _investors = new List<IInvestor>();

        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in _investors)
            {
                investor.Update(this);
            }
        }
    }
}
