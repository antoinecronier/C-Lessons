using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WpfApplication1.View.Base
{
    public class BaseNavigationWindow : NavigationWindow
    {
        public BaseNavigationWindow()
        {
        }

        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);

        }
    }
}
