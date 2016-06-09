using App1.Model;
using App1.MyUserControl.Base;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App1.MyUserControl
{
    public sealed partial class ProductUserControl : BaseUserControl
    {
        #region attributs
        private Product product;
        #endregion

        #region properties
        public Product Product
        {
            get
            {
                return this.product;
            }

            set
            {
                this.product = value;
                base.OnPropertyChanged("Product");
            }
        }
        #endregion

        #region constructor
        public ProductUserControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region methods

        #endregion
    }
}
