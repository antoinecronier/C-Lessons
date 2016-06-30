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
using System.Windows.Shapes;

namespace WpfApplication1.View
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void navigationwindows_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Window2(); //create your new form.
            newForm.InitializeComponent(); //show the new form.
            //Window main = Application.Current.MainWindow as Window;
        }

        private void navigatetobase_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Window(); //create your new form.
            newForm.Content = new Page();
            newForm.Show(); //show the new form.
        }
    }
}
