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
            //MysqlTest1();
            //WebService();
            //TestEF6C1C2();
            //Events();
            Logs();
            //SQLiteTest();
        }

        private async void MysqlTest1()
        {
            MySQLManager<Class1> manager = new MySQLManager<Class1>(DataConnectionResource.LOCALMYSQL);
            EntityGenerator<Class1> generator = new EntityGenerator<Class1>();
            //Class1 item = generator.GenerateItem();
            Class1 item = new Class1();
            item = generator.GenerateItem();
            item.Address = new Class2();
            item.Id = 2;
            item.AddressId = 28;
            item.Address.Id = 28;

            var res = await manager.Update(item);

            var items = await manager.Get() as List<Class1>;
            foreach (var iteme in items)
            {
                iteme.Name = "test";
            }

            await manager.Update(items);
        }

        private async void WebService()
        {
            WebServiceManager<ClassA> webManager = new WebServiceManager<ClassA>(DataConnectionResource.LOCALAPI);
            EntityGenerator<ClassA> gen = new EntityGenerator<ClassA>();
            List<ClassA> classAs = gen.GenerateListItems() as List<ClassA>;

            await webManager.Post(classAs);

            var result = await webManager.Get();
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
            Logger2 logger2 = new Logger2("MyLogger", LogMode.CURRENT_FOLDER, AlertMode.CONSOLE);
            //logger2.Log("bonjour", "mon message");
            //logger2.Log(new Exception("New Exception message"),"Error occured");

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            this.clientView.UCClient.clientBillTxtB.Text = "hey";
                        }
                        catch (Exception e)
                        {
                            logger2.Log("error :" + i);
                            i++;
                        }
                    });
                }
            });


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

            //Logger logger4 = new Logger("current folder", LogMode.CURRENT_FOLDER, AlertMode.OVERLAY);
            //logger4.Log("logger 4 to current folder");
            //Task.Factory.StartNew(() =>
            //{
            //    for (int i = 0; i < 1000000000; i++)
            //    {
            //        logger4.Log("next reported lognext reported lognext reported lognext reported lognext reported lognext reported lognext reported lognext reported lognext");
            //    }
            //});

            //logger4.Log("other");
        }

        private void Events()
        {
            ClassWithEvent2 event2 = new ClassWithEvent2();
            event2.Handler += Event2_Handler;
            event2.Handler += Event2_Handler2;
            event2.Handler1 += Event2_Handler1;

            event2.OnHandler(new EventArgs());

            #region Implementation example
            Product myProduct = new Product();
            myProduct.Name = "roue";
            myProduct.Value = 15;
            myProduct.Stock.Number = 20;
            myProduct.Stock.Number = 5;
            myProduct.Stock.Number = 20;
            #endregion


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

        private void Event2_Handler2(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Event2_Handler1(object sender, ClassWithEvent2 e)
        {
            //throw new NotImplementedException();
        }

        private void Event2_Handler(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
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
            MySQLManager<Class1> managerC1 = new MySQLManager<Class1>(DataConnectionResource.LOCALMYSQL);
            EntityGenerator<Class1> gen = new EntityGenerator<Class1>();
            EntityGenerator<Class2> gen1 = new EntityGenerator<Class2>();
            Class1 c1 = gen.GenerateItem();
            c1.Addresses = gen1.GenerateListItems() as List<Class2>;
            await managerC1.Insert(c1);
            var result = await managerC1.Get() as List<Class1>;
            c1.Addresses.Add(gen1.GenerateItem());
            await managerC1.Update(c1);
            var result1 = await managerC1.Get() as List<Class1>;
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
