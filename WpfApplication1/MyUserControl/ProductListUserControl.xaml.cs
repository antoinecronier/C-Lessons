using App1.Model;
using App1.MyUserControl.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

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
        #endregion
    }
}
