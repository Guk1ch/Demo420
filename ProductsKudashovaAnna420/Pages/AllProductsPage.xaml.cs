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
using ProductsKudashovaAnna420.DB;

namespace ProductsKudashovaAnna420.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllProductsPage.xaml
    /// </summary>
    public partial class AllProductsPage : Page
    {
        public static List<Product> products {  get; set; }
        public static List<ProductType> productTypes { get; set; }
        public AllProductsPage()
        {
            InitializeComponent();

            products = new List<Product>(DBConnection.productsDemo.Product.ToList());
            productTypes = new List<ProductType>(DBConnection.productsDemo.ProductType.ToList());

            ProductsLv.ItemsSource = products;

            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsLv.SelectedItem is Product product)
            {
                DBConnection.productsDemo.Product.Remove(product);
                DBConnection.productsDemo.SaveChanges();
            }
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
