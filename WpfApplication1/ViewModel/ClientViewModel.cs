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
using ClassLibrary2.Entities.Base;
using System.Data.SqlClient;
using ClassLibrary2;
using SQLite.Net;

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
            //MysqlTest();
            //TestEF6C1C2();
            //Events();
            //Logs();
            SQLiteTest();
        }

        private void SQLiteTest()
        {
            SQLiteManager<Client> managerClient = new SQLiteManager<Client>(AppDomain.CurrentDomain.BaseDirectory + "\\mydb");
            SQLiteManager<Product> managerProduct = new SQLiteManager<Product>(AppDomain.CurrentDomain.BaseDirectory + "\\mydb");
            EntityGenerator<Client> generatorClient = new EntityGenerator<Client>();
            EntityGenerator<Product> generatorProduct = new EntityGenerator<Product>();

            List<Client> clients = generatorClient.GenerateListItems() as List<Client>;
            int resultClient = managerClient.InsertOrIgnoreAll(clients);
            //var client1Result = managerClient.Find<Client>(188);
            var client2Result = managerClient.Get<Client>(clients[0].Id);

            var client3Result = managerClient.FindWithQuery<Client>("SELECT * FROM client WHERE id = @p1", new object[] { 20 });
            var client4Result = managerClient.Query<Client>("SELECT * FROM client WHERE id = @p1", new object[] { 20 });
            //var client5Result = managerClient.Execute("INSERT INTO client VALUES(666,'name','surname',666,666)");

            managerClient.BeginTransaction();
            for (int x = 64; x < 666; x++)
            {
                managerClient.ExecuteScalar<Client>("INSERT INTO client VALUES(@p1,'name','surname',@p2,@p3)", new object[] { x, x + 1, x + 2 });
            }
            managerClient.Commit();

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

        private void Logs()
        {
            //Logger logger = new Logger();
            //logger.Log("Default logger welcome");
            //logger.Log("With temp options", LogMode.CONSOLE);

            //Logger logger1 = new Logger("MyLogger", LogMode.CONSOLE, AlertMode.CONSOLE);
            //logger1.Log("Welcome from custom logger");

            //Logger logger2 = new Logger();
            //logger2.Log("With temp options", LogMode.CONSOLE, AlertMode.MESSAGE_BOX);

            //Logger logger3 = new Logger("overlay",LogMode.CONSOLE, AlertMode.OVERLAY);
            //for (int i = 0; i < 4; i++)
            //{
            //    logger3.Log("First one");
            //    logger3.Log("Second one ");
            //}

            Logger logger4 = new Logger("current folder", LogMode.CURRENT_FOLDER, AlertMode.OVERLAY);
            logger4.Log("logger 4 to current folder");
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    logger4.Log("next reported lognext reported lognext reported lognext reported lognext reported lognext reported lognext reported lognext reported lognext");
                }
            });
            
            logger4.Log("other");
        }

        private void Events()
        {
            #region Events
            ClassWithEvent event1 = new ClassWithEvent();
            event1.Changed += Event1_Changed;
            event1.Handler += Event1_Handler;
            event1.CustomClassAEvent += Event1_CustomClassAEvent;
            event1.CustomEventArg += Event1_CustomEventArg;
            event1.OnChanged(new EventArgs());
            event1.OnHandler(new EventArgs());
            event1.OnCustomClassAEvent(new ClassA());
            CustomEventArgs args = new CustomEventArgs();
            args.CurrentClass = this;
            args.Message = "Welcome from event";
            args.Logger = new Logger("ClientViewModel",LogMode.CONSOLE,AlertMode.CONSOLE);
            event1.OnCustomEventArg(args);

            //ClassWithEvent event2 = new ClassWithEvent();
            //event2.Changed += Event1_Changed;
            //event2.Handler += Event1_Handler;
            //event2.CustomClassAEvent += Event1_CustomClassAEvent;
            //event2.OnChanged(new EventArgs());
            //event2.OnHandler(new EventArgs());
            //event2.OnCustomClassAEvent(new ClassA());

            //ClassWithEvent event3 = new ClassWithEvent();
            //event3.Changed += Event1_Changed;
            //event3.Handler += Event1_Handler;
            //event3.CustomClassAEvent += Event1_CustomClassAEvent;
            //event3.OnChanged(new EventArgs());
            //event3.OnHandler(new EventArgs());
            //event3.OnCustomClassAEvent(new ClassA());
            #endregion
        }

        private void Event1_CustomEventArg(object sender, CustomEventArgs e)
        {
            e.Logger.Log("Message Receive");
        }

        private void Event1_CustomClassAEvent(object sender, ClassA e)
        {
            //Console.WriteLine("Fired custom event");
        }

        private void Event1_Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Fired Handled");
        }

        private void Event1_Changed(object sender, EventArgs e)
        {
            //Console.WriteLine("Fired Changed");
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

            //Class1 client = managerClass1.DbSetT.SqlQuery("SELECT * FROM " + Class1Schema.TABLE + " WHERE id = 1",new object[] { }).ToListAsync().Result[0];
            //Class1 client = managerClass1.DbSetT.SqlQuery("@param1, @param2, @param3",
            //    new SqlParameter("param1", "SELECT * FROM "),
            //    new SqlParameter("param2", Class1Schema.TABLE),
            //    new SqlParameter("param3", " WHERE id = 1")).FirstAsync().Result;
            //var result = await managerClass1.DbSetT.SqlQuery("SELECT " + Class1Schema.ID + ", " + Class1Schema.NAME + ", " + Class1Schema.SURNAME + ", " + Class1Schema.ADDRESS_ID +" FROM " + Class1Schema.TABLE).ToListAsync();

            //Func<Class1, Boolean> testFunction = new Func<Class1, bool>((x, y) => 
            //{
            //    if (true)
            //    {

            //        return true;
            //    }
            //    else
            //    {

            //        return false;
            //    }
            //});

            //var result1 = managerClass1.DbSetT.SqlQuery("SELECT * FROM "+ Class1Schema.TABLE + ";").AllAsync(testFunction);

            String queryString = string.Format("SELECT * FROM {0} {1} {2} {3} {4};", Class1Schema.TABLE, "WHERE", Class1Schema.NAME, "LIKE", "'%s'");
            queryString = string.Format("SELECT * FROM {0};", Class1Schema.TABLE);

            var result = await managerClass1.DbSetT.SqlQuery(queryString).ToListAsync();

            Criteria criteria = new Criteria(DbAction.SELECT, EnumString.GetStringValue(DbSelector.ALL));
            criteria.AddDbLink(Class1Schema.TABLE, DbLinks.FROM);
            criteria.AddDbLink(Class2Schema.TABLE, DbLinks.INNERJOIN, new LinkCondition(Class1Schema.PREFIX_ADDRESS_ID,Class2Schema.PREFIX_ID));
            criteria.AddCriterion(new Criterion(DbVerb.EMPTY, Class1Schema.NAME, DbOperator.LIKE, "'%s'"));
            criteria.AddCriterion(new Criterion(DbVerb.OR, Class1Schema.SURNAME, DbOperator.IN, "('RebeckaGotts', 'JesseAguas')"));

            String value = criteria.MySQLCompute();
            var result1 = await managerClass1.CustomQuery(criteria);


            //MySQLManager<Class2> managerClass2 = new MySQLManager<Class2>(DataConnectionResource.LOCALMYSQL);

            //Criteria criteria1 = new Criteria(DbAction.DELETE, Class1Schema.ALL_TABLE_ELEMENT + ", " + Class2Schema.ALL_TABLE_ELEMENT);
            //criteria1.AddDbLink(Class2Schema.TABLE, DbLinks.FROM);
            //criteria1.AddDbLink(Class1Schema.TABLE, DbLinks.INNERJOIN, new LinkCondition(Class2Schema.PREFIX_CLASS1_ID, Class1Schema.PREFIX_ID));
            //criteria1.AddCriterion(new Criterion(DbVerb.EMPTY, Class2Schema.PREFIX_CLASS1_ID, DbOperator.SUPERIOREQUAL, "4"));

            //String value1 = criteria1.MySQLCompute();
            //await managerClass2.CustomQuery(criteria1);
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
