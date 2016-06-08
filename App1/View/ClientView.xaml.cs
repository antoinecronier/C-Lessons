using App1.MyUserControl;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ClientView : Page
    {
        #region attributs

        #endregion

        #region properties
        public ClientUserControl ClientUserControl { get; set; }
        public ProductListUserControl ProductListUserControlBuy { get; set; }
        public ProductListUserControl ProductListUserControlAvaiable { get; set; }
        public ProductUserControl ProductUserControl { get; set; }
        public AddRemoveUserControl AddRemoveUserControl { get; set; }
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
        }
        #endregion

        #region methods

        #endregion
    }
}
