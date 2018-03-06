using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

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
            var newForm = new Window2();
            newForm.Show();
        }

        private void navigatetobase_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new Window(); //create your new form.
            newForm.Content = new ClientView();
            newForm.Show(); //show the new form.
        }

        private void navigatetoframe_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Color.FromRgb(10,10,200));
            this.Opacity = 0.7;

            //(((Application.Current.MainWindow as Window).Content as Frame).Content as Page).Background = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            //(((Application.Current.MainWindow as Window).Content as Frame).Content as Page).Opacity = 0.3;

            Task.Delay(TimeSpan.FromSeconds(3)).ContinueWith((x)=> {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    var recycle = new Window1();
                    recycle.Show();

                    this.Close();
                }));
            });
        }

        private void navigationwindows_MouseEnter(object sender, MouseEventArgs e)
        {
            int a = 1;
            a += 3;
            MessageBox.Show(a.ToString());
        }
    }
}
