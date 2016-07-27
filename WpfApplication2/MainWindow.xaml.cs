using ClassLibrary2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
            //Test();
        }

        private void Init()
        {
            Class1 c1 = new Class1();
            c1.Id = 2;
            c1.Name = "toto";
            c1.Surname = "tata";
            this.UC1.Class1 = c1;
        }

        private void Test()
        {
            pokedex pokedex = new pokedex();
            pokedex.id_pokedex = 2500;

            using (var db = new pokesandraEntities())
            {
                db.pokedex.Add(pokedex);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.pokedex
                            orderby b.id_pokedex
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.id_pokedex);
                }
            }
        }
    }
}
