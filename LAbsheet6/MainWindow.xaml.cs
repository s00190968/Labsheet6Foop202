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

namespace LAbsheet6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQuery_click(object sender, RoutedEventArgs e)
        {
            var query = db.Customers.Select(c => c.CompanyName);

            lbxCustomersEx1.ItemsSource = query.ToList();
        }

        private void btnQuery_click2(object sender, RoutedEventArgs e)
        {
            var query = db.Customers.Select(c => c);

            dgrCustomersEx2.ItemsSource = query.ToList();
        }

        private void btnQuery_click3(object sender, RoutedEventArgs e)
        {

        }
    }
}
