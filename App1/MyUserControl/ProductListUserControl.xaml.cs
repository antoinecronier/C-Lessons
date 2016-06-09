using App1.Model;
using App1.MyUserControl.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ProductListUserControl : BaseUserControl
    {
        #region attributs
        #endregion

        #region properties
        public ListView ItemsList { get; set; }
        public ObservableCollection<Product> Obs { get; set; }
        #endregion

        #region constructor
        public ProductListUserControl()
        {
            this.InitializeComponent();
            Obs = new ObservableCollection<Product>();
            this.itemsList.ItemsSource = Obs;
            this.ItemsList = this.itemsList;
        }
        #endregion

        #region methods
        /// <summary>
        /// Current list for User items.
        /// </summary>
        public void LoadItem(List<Product> items)
        {
            Obs.Clear();
            foreach (var item in items)
            {
                Obs.Add(item);
            }
        }
        #endregion

        #region events
        private void itemsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TODO implement
        }
        #endregion
    }
}
