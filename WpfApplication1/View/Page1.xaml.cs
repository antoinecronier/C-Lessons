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

namespace WpfApplication1.View
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void navigation_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientView());
        }

        private void navigationThrow_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Window1(); //create your new form.
            newForm.Show(); //show the new form.
            Window main = Application.Current.MainWindow as Window;
            main.Close();
        }
    }
}
