using System;
using System.Threading.Tasks;
using App1.View;
using App1.Model;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using System.Threading;
using WpfApplication1.Sandbox;
using ClassLibrary1;
using ClassLibrary2.Database;

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
            Preproc preproc = new Preproc();
            Sandbox sb = new Sandbox();
            MysqlTest();
        }
        #endregion

        #region methods
        private async void MysqlTest()
        {
            MySQLManager<ClassA> manager = new MySQLManager<ClassA>();
            ClassA test = new ClassA();
            test.Field1 = 1;
            test.Field2 = "2";
            test.Field3 = "3";
            manager.InsertInMySQL(test);

            ClassA test1 = new ClassA();
            test1 = manager.GetFromMySQL(1);
        }

        private void LoadItems()
        {
            this.clientView.ClientUserControl.Client = new BaseItems.BaseItemClient();
            this.clientView.ProductListUserControlAvaiable.LoadItem(new BaseItems.BaseItemProduct().getItemList());
        }

        private void LinkItems()
        {
            this.clientView.ProductListUserControlAvaiable.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
            this.clientView.ProductListUserControlBuy.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
            this.clientView.BuyButton.Click += BuyButton_Click;
        }

        private void BuyButton_Click(object sender, System.Windows.RoutedEventArgs e)
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

        public void UpdateIt()
        {
            Int32 i = 0;
            while (i < Int32.MaxValue)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    this.clientView.ClientUserControl.Client.Sold = i;
                        i++;
                }));
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
        private void ItemsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.clientView.AddRemoveUserControl.AddBtn.Click -= AddBtn_Click;
            this.clientView.AddRemoveUserControl.RemoveBtn.Click -= RemoveBtn_Click;
            this.selectedProduct = (Product)e.AddedItems[0];
            this.clientView.ProductUserControl.Product = this.selectedProduct;
            this.clientView.AddRemoveUserControl.AddBtn.Click += AddBtn_Click;
            this.clientView.AddRemoveUserControl.RemoveBtn.Click += RemoveBtn_Click;
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.clientView.ProductListUserControlBuy.Obs.Contains(this.selectedProduct))
            {
                this.clientView.ProductListUserControlBuy.Obs.Remove(this.selectedProduct);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.clientView.ProductListUserControlBuy.Obs.Add(this.selectedProduct);
        }
        #endregion
    }
}
