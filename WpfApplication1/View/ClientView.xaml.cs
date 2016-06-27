﻿using App1.MyUserControl;
using App1.ViewModel;
using System.Windows.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ClientView : Page
    {
        #region attributs
        private ClientViewModel clientViewModel;
        #endregion

        #region properties
        public ClientUserControl ClientUserControl { get; set; }
        public ProductListUserControl ProductListUserControlBuy { get; set; }
        public ProductListUserControl ProductListUserControlAvaiable { get; set; }
        public ProductUserControl ProductUserControl { get; set; }
        public AddRemoveUserControl AddRemoveUserControl { get; set; }
        public Button BuyButton { get; set; }

        public ClientViewModel ClientViewModel
        {
            get { return clientViewModel; }
            set { clientViewModel = value; }
        }

        #endregion

        #region constructor
        public ClientView()
        {
            this.InitializeComponent();
            this.ClientUserControl = this.UCClient;
            this.ProductListUserControlBuy = this.LUCProductBuy;
            this.ProductListUserControlAvaiable = this.LUCProductAvaiable;
            this.ProductUserControl = this.UCProduct;
            this.AddRemoveUserControl = this.UCAddRemove;
            this.BuyButton = this.BuyBtn;
            this.ClientViewModel = new ClientViewModel(this);
        }
        #endregion

        #region methods

        #endregion
    }
}