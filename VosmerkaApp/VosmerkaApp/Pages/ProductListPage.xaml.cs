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
using VosmerkaApp.DB;

namespace VosmerkaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            ProductLv.ItemsSource = DB.Connection.db.Product.ToList();

            List<String> products = new List<String>();

            foreach (ProductType type in DB.Connection.db.ProductType)
            {
                products.Add(type.Title);
            }

            FilterCb.ItemsSource = products;
        }

        private void ProductLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage(ProductLv.SelectedItem as Product));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage(new Product()));
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductLv.ItemsSource = DB.Connection.db.Product.Where(i=>i.Title.StartsWith(SearchTb.Text)).ToList();
        }

        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductLv.ItemsSource = DB.Connection.db.Product.Where(i => i.ProductTypeID == FilterCb.SelectedIndex+1).ToList();

        }

        private void MaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaterialListPage());
        }
    }
}
