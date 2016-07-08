using System;
using System.Threading.Tasks;
using App1.Model;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using System.Threading;
using WpfApplication1.Sandbox;
using ClassLibrary1;
using ClassLibrary2.Database;
using ClassLibrary2.WebService;
using System.Collections.Generic;
using ClassLibrary2.EnumManager;
using ClassLibrary2.Genericity;
using ClassLibrary2.JSON;
using WpfApplication1.View;
using ClassLibrary2.Observer.Testing;
using ClassLibrary2.Events;
using ClassLibrary2.Entities;
using ClassLibrary2.Entities.Generator;

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
            //Preproc preproc = new Preproc();
            //Sandbox sb = new Sandbox();
            MysqlTest();
            TestEF6C1C2();
        }

        private async void TestEF6C1C2()
        {
            Class1 c1 = new Class1();
            EntityGenerator<Class1> generatorClass1 = new EntityGenerator<Class1>();
            c1 = generatorClass1.GenerateItem();

            EntityGenerator<Class2> generatorClass2 = new EntityGenerator<Class2>();
            for (int i = 0; i < 10; i++)
            {
                c1.Addresses.Add(generatorClass2.GenerateItem());
            }

            MySQLManager<Class1> managerClass1 = new MySQLManager<Class1>(DataConnectionResource.LOCALMYSQL);
            c1 = await managerClass1.Insert(c1);
            Class1 c11 = await managerClass1.Get(c1.Id);
        }
        #endregion

        #region methods
        private async void MysqlTest()
        {
            //#region MysqlDirectConnect
            //MySQLManager<ClassA> manager = new MySQLManager<ClassA>(DataConnectionResource.LOCALMYQSL);
            //ClassA test1 = new ClassA();
            //test1.Field1 = 1;
            //test1.Field2 = "2";
            //test1.Field3 = "3";
            //await manager.Insert(test1);

            //ClassA test2 = new ClassA();
            //test2 = await manager.Get(test1.Field1);

            //test2.Field2 = "youhou";
            //await manager.Update(test1);

            //ClassA test3 = new ClassA();
            //test3 = await manager.Get(test1.Field1);

            //List<ClassA> items = new List<ClassA>();
            //ClassA test4 = new ClassA();
            //test4.Field1 = 20;
            //test4.Field2 = "20";
            //ClassA test5 = await manager.Get(test3.Field1);
            //test5.Field3 = "21";
            ////ClassA test6 = ((await manager.Get()) as List<ClassA>)[2];
            ////test6.Field2 = "manager.GetAll()[6]";
            //items.Add(test4);
            //items.Add(test5);
            ////items.Add(test6);
            //await manager.Update(items);
            //List<ClassA> items1 = await manager.Get() as List<ClassA>;
            //await manager.Delete(items1);
            //await manager.Insert(test1);
            //ClassC c = new ClassC();
            //c.Field1 = 9;
            //(c as ClassA).Field1 = 18;

            //#endregion

            //#region MysqlFromAPI
            //WebServiceManager<ClassA> webManager = new WebServiceManager<ClassA>(DataConnectionResource.LOCALAPI);
            //ClassA test01 = new ClassA();
            //test01 = await webManager.Get(test1.Field1);
            //List<ClassA> tests0 = new List<ClassA>();
            //tests0 = await webManager.Get();
            //ClassA test02 = new ClassA();
            //test02.Field2 = "posted";
            //test02.Field3 = "in API";
            //ClassA test03 = await webManager.Post(test02);
            //test03.Field2 = "coconut";
            //test03.Field3 = "cherry";
            //ClassA test04 = await webManager.Put(test03);

            //foreach (var item in tests0)
            //{
            //    item.Field1 = 0;
            //    item.Field2 += " newest"; 
            //}

            //var res = await webManager.Post(tests0);
            ////await webManager.Delete(res[0]);
            //var res1 = await webManager.Delete(res);
            //var res2 = await webManager.Get();

            //#endregion

            //#region WebService
            //WebServiceManager<ClassA> webServiceA = new WebServiceManager<ClassA>(DataConnectionResource.LOCALAPI);
            //WebServiceManager<ClassB> webServiceB = new WebServiceManager<ClassB>(DataConnectionResource.LOCALAPI);
            //WebServiceManager<ClassC> webServiceC = new WebServiceManager<ClassC>(DataConnectionResource.LOCALAPI);
            //WebServiceManager<ClassD> webServiceD = new WebServiceManager<ClassD>(DataConnectionResource.LOCALAPI);

            //ClassA a = new ClassA();
            //a.Field2 = "a";
            //a.Field3 = "A";
            //await webServiceA.Post(a);
            //await webServiceA.Get(2);
            //await webServiceA.Put(a);
            //await webServiceA.Delete(a);

            //ClassB b = new ClassB();
            //b.Field2 = "b";
            //b.Field3 = "B";
            //await webServiceB.Post(b);

            //ClassC c = new ClassC();
            //c.Field2 = "c";
            //c.Field3 = "C";
            //c.Field4 = 4;
            //await webServiceC.Post(c);

            //ClassD d = new ClassD();
            //d.Field2 = "d";
            //d.Field3 = "D";
            //d.Field4 = 4;
            //d.Field5 = 5;
            //await webServiceD.Post(d);
            //#endregion

            //#region Observers
            //Test3 test3 = new Test3();
            //Test2 test20 = new Test2();
            //Test2 test21 = new Test2();
            //Test2 test22 = new Test2();

            //test3.Attach(test20);
            //test3.Attach(test21);
            //test3.Attach(test22);

            //test3.Notify();
            //test3.MyProperty1 = "JeanDuToto";

            //#endregion

            #region Events
            ClassWithEvent event1 = new ClassWithEvent();
            event1.Changed += Event1_Changed;
            event1.Handler += Event1_Handler;
            event1.CustomClassAEvent += Event1_CustomClassAEvent;
            event1.OnChanged(new EventArgs());
            event1.OnHandler(new EventArgs());
            event1.OnCustomClassAEvent(new ClassA());
            #endregion

            //#region Enums
            //EnumTester tester = new EnumTester();
            //#endregion

            //#region Genericity
            //Genericitycs gene = new Genericitycs();
            //Genericitycs2<ClassA> gene2 = new Genericitycs2<ClassA>();
            //#endregion

            //#region JSON
            //Json json = new Json();
            //#endregion
        }

        private void Event1_CustomClassAEvent(object sender, ClassA e)
        {
            Console.WriteLine("Fired custom event");
        }

        private void Event1_Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Fired Handled");
        }

        private void Event1_Changed(object sender, EventArgs e)
        {
            Console.WriteLine("Fired Changed");
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
