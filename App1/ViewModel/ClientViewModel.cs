using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.View;
using App1.Model;
using Windows.ApplicationModel.Core;
using System.Diagnostics;
using Windows.Storage;
using ClassLibrary2.Entities.Generator;
using SQLite.Net;
using Microsoft.Azure.Engagement;

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
            SQLiteTest();
            Engagement();
        }

        private void Engagement()
        {
            String deviceId = EngagementAgent.Instance.GetDeviceId();
            Task.Factory.StartNew(() =>
            {
                //Task.Delay(TimeSpan.FromSeconds(4)).Wait();
                //EngagementAgent.Instance.Terminate();
                Task.Delay(TimeSpan.FromSeconds(2)).Wait();
                EngagementAgent.Instance.StartActivity("hey");
            });
            EngagementReach.Instance.PushMessageReceived += Instance_PushMessageReceived;
        }

        private void Instance_PushMessageReceived(int arg1, bool arg2, string arg3)
        {
            int a = 0;
            a++;
        }
        #endregion

        #region methods
        private void SQLiteTest()
        {
            SQLiteManager<Client> managerClient = new SQLiteManager<Client>(ApplicationData.Current.LocalFolder.Path + "\\mydb");
            SQLiteManager<Product> managerProduct = new SQLiteManager<Product>(ApplicationData.Current.LocalFolder.Path + "\\mydb");
            EntityGenerator<Client> generatorClient = new EntityGenerator<Client>();
            EntityGenerator<Product> generatorProduct = new EntityGenerator<Product>();

            List<Client> clients = generatorClient.GenerateListItems() as List<Client>;
            foreach (var item in clients)
            {
                item.Products = generatorProduct.GenerateListItems() as List<Product>;
            }
            int resultClient = managerClient.InsertAll(clients);
            var client1Result = managerClient.Find<Client>(clients[0].Id);
            var client2Result = managerClient.Get<Client>(clients[0].Id);

            var client3Result = managerClient.FindWithQuery<Client>("SELECT * FROM client WHERE id = @p1", new object[] { 20 });
            var client4Result = managerClient.Query<Client>("SELECT * FROM client WHERE id = @p1", new object[] { 20 });
            //var client5Result = managerClient.Execute("INSERT INTO client VALUES(666,'name','surname',666,666)");

            //managerClient.BeginTransaction();
            //for (int x = 64; x < 666; x++)
            //{
            //    managerClient.ExecuteScalar<Client>("INSERT INTO client VALUES(@p1,'name','surname',@p2,@p3)", new object[] { x, x+1, x+2 });
            //}
            //managerClient.Commit();

            List<Client> clients1 = generatorClient.GenerateListItems() as List<Client>;
            managerClient.InsertOrReplaceAll(clients1);

            clients[0].Id = 1971277679;
            clients[0].Name = "trololol";
            managerClient.Update(clients[0]);

            managerClient.Delete<Client>(clients[0].Id);
            managerClient.DeleteAll<Client>();
            
            List<Product> products = generatorProduct.GenerateListItems() as List<Product>;
            int resultProduct = managerProduct.InsertAll(products);
            var product1Result = managerProduct.Find<Product>(products[0].Id);
        }

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
