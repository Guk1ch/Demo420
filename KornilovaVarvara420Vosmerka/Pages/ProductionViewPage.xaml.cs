using KornilovaVarvara420Vosmerka.DB;
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

namespace KornilovaVarvara420Vosmerka.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductionViewPage.xaml
    /// </summary>
    public partial class ProductionViewPage : Page
    {
        public static List<Product> products {  get; set; }
        public static List<ProductType> productsType { get; set; }
        public ProductionViewPage()
        {
            InitializeComponent();
            Refresh(0);
            products = new List<Product>(DBConnection.vosmerkaEntities.Product.ToList());
            productsType = new List<ProductType>(DBConnection.vosmerkaEntities.ProductType.ToList());
            ProductsLV.ItemsSource = products;
            filtrCB.ItemsSource = productsType;
            productsType.Insert(0, new ProductType() { Title = "Все" });


            this.DataContext = this;
        }

        public void Refresh(int i)
        {
            var allproducts = DBConnection.vosmerkaEntities.Product.ToList();
            var filtered = allproducts.AsQueryable();

            var searching = SearchTB.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(searching))
            {
                filtered = filtered.Where(x => x.Title.ToLower().Contains(searching));
            }

            var title = filtrCB.SelectedItem as ProductType;
            if (filtrCB.SelectedIndex >= 0 && title != null)
            {
                filtered = filtered.Where(x => x.ProductTypeID == title.ID);
                //if (filtrCB.SelectedIndex == 0)
                //{
                //    ProductsLV.ItemsSource = filtered.ToList();
                //}
            }

            ProductsLV.ItemsSource = filtered.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh(0);
        }

        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filtrCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh(0);
        }

        private void AddProductBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }

        private void EditProductBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsLV.SelectedItem is Product product)
            {
                NavigationService.Navigate(new EditProductPage(product));
            }
            SearchTB.Text = "";
            Refresh(0);
        }

        private void RemoveProductBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsLV.SelectedItem is Product product)
            {
                DBConnection.vosmerkaEntities.Product.Remove(product);
                DBConnection.vosmerkaEntities.SaveChanges();
            }


            SearchTB.Text = "";
            Refresh(0);
        }
    }
}
