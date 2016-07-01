using App1.Model;
using App1.MyUserControl.Base;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

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

        #region UserControlBinderPropertie
        public String Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValueDp(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string),
                typeof(ProductUserControl), null);

        public event PropertyChangedEventHandler PropertyChangedText;
        public void SetValueDp(DependencyProperty property, object value,
            [System.Runtime.CompilerServices.CallerMemberName] String p = null)
        {
            SetValue(property, value);
            if (PropertyChangedText != null)
            {
                PropertyChangedText(this, new PropertyChangedEventArgs(p));
            }
        }
        #endregion

        /*public TextBlock TextBlock1
        {
            get { return productNameTxtB; }
            set {
                productNameTxtB = value;
                base.OnPropertyChanged("TextBlock1");
            }
        }

        public TextBlock TextBlock2
        {
            get { return productValueTxtB; }
            set {
                productValueTxtB = value;
                base.OnPropertyChanged("TextBlock2");
            }
        }*/
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
