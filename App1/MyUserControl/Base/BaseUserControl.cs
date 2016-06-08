using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace App1.MyUserControl.Base
{
    public class BaseUserControl : UserControl, INotifyPropertyChanged
    {
        #region attributs
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region properties

        #endregion

        #region constructor

        #endregion

        #region methods
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
