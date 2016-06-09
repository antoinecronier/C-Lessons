using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.View;
using App1.Model;
using Windows.ApplicationModel.Core;
using System.Diagnostics;

namespace App1.ViewModel
{
    public class ClientViewModel
    {
        #region attributs
        private ClientView clientView;
        private Product selectedProduct;
        #endregion

        #region properties

        #endregion

        #region constructor
        public ClientViewModel(ClientView clientView)
        {
            this.clientView = clientView;
            LoadItems();
            LinkItems();
        }
        #endregion

        #region methods
        private void LoadItems()
        {
            this.clientView.ClientUserControl.Client = new BaseItems.BaseItemClient();
            this.clientView.ProductListUserControlAvaiable.LoadItem(new BaseItems.BaseItemProduct().getItemList());
        }

        private void LinkItems()
        {
            this.clientView.ProductListUserControlAvaiable.ItemsList.ItemClick += ItemsList_ItemClick;
            this.clientView.ProductListUserControlBuy.ItemsList.ItemClick += ItemsList_ItemClick;
            this.clientView.BuyButton.Tapped += BuyButton_Tapped;
        }

        private void BuyButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            /*Int32 i = 0;
            Task.Factory.StartNew(() => 
            {
                while (i < Int32.MaxValue)
                {
                    i++;
                }
            }).Wait();

            Debug.WriteLine(i);*/

            //Freeze();
            UpdateIt();
        }

        public async void UpdateIt()
        {
            Int32 i = 0;
            while (i < Int32.MaxValue)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    Windows.UI.Core.CoreDispatcherPriority.Normal,
                    () =>
                    {
                        this.clientView.ClientUserControl.Client.Sold = i;
                        i++;
                    });
                Debug.WriteLine(i);
            }
        }

        /*public async void UpdateIt()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    int result = 0;
                    foreach (var item in this.clientView.ProductListUserControlBuy.Obs)
                    {
                        result += item.Value;
                    }

                    if (result <= this.clientView.ClientUserControl.Client.Sold)
                    {
                        this.clientView.ClientUserControl.Client.Sold -= result;
                    }
                });
        }*/

        public async void Freeze()
        {
            await someThing();
            throw new Exception();
        }

        private Task someThing()
        {
            Action action = new Action(() =>
            {
                int i = 0;
                while (true)
                {
                    Debug.WriteLine(i);
                    i++;
                }
            });

            return Task.Run(action);
        }


        #endregion

        #region events
        private void ItemsList_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            this.clientView.AddRemoveUserControl.AddBtn.Tapped -= AddBtn_Tapped;
            this.clientView.AddRemoveUserControl.RemoveBtn.Tapped -= RemoveBtn_Tapped;
            this.selectedProduct = (Product)e.ClickedItem;
            this.clientView.ProductUserControl.Product = this.selectedProduct;
            this.clientView.AddRemoveUserControl.AddBtn.Tapped += AddBtn_Tapped;
            this.clientView.AddRemoveUserControl.RemoveBtn.Tapped += RemoveBtn_Tapped;
        }

        private void RemoveBtn_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (this.clientView.ProductListUserControlBuy.Obs.Contains(this.selectedProduct))
            {
                this.clientView.ProductListUserControlBuy.Obs.Remove(this.selectedProduct);
            }
        }

        private void AddBtn_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            this.clientView.ProductListUserControlBuy.Obs.Add(this.selectedProduct);
        }
        #endregion
    }
}
