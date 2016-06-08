using App1.Model;
using App1.MyUserControl.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App1.MyUserControl
{
    public sealed partial class ClientUserControl : BaseUserControl
    {
        #region attributs
        private Client client;
        #endregion

        #region properties
        public Client Client
        {
            get
            {
                return this.client;
            }

            set
            {
                this.client = value;
                base.OnPropertyChanged("Client");
            }
        }
        #endregion

        #region constructor
        public ClientUserControl()
        {
            this.InitializeComponent();
        }
        #endregion

        #region methods

        #endregion
    }
}
