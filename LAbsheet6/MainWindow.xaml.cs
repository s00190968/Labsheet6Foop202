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
            var q = db.Orders.Where(o =>
            o.Customer.City.Equals("London") ||
            o.Customer.City.Equals("Paris") ||
            o.Customer.City.Equals("USA")).OrderBy(o => o.Customer.CompanyName)
            .Select(o => new {
                CustomerName = o.Customer.CompanyName,
                City = o.Customer.City,
                Address = o.ShipAddress
            });

            dgrCustomersEx3.ItemsSource = q.ToList().Distinct();
        }

        private void btnQuery_click4(object sender, RoutedEventArgs e)
        {
            ShowProducts(dgrCustomersEx4);
        }

        private void ShowProducts(DataGrid current)
        {
            var q = db.Products.Where(p => p.Category.CategoryName.Equals("Beverages"))
                .OrderByDescending(p => p.ProductID).Select(p => new
                {
                    p.ProductID,
                    p.ProductName,
                    p.Category.CategoryName,
                    p.UnitPrice
                });
            current.ItemsSource = q.ToList();
        }

        private void btnQuery_click5(object sender, RoutedEventArgs e)
        {
            Product p = new Product()
            {
                ProductName = "Kickapoo Jungle Joy Juice",
                UnitPrice = 12.49m,
                CategoryID = 1
            };

            db.Products.Add(p);
            db.SaveChanges();

            ShowProducts(dgrCustomersEx5);
        }
    }
}
