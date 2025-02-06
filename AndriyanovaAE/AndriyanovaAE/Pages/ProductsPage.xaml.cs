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
using AndriyanovaAE.DB;

namespace AndriyanovaAE.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public List<Product> products {get; set;}
        public List<ProductType> productTypes { get; set;}

        public ProductsPage()
        {
            InitializeComponent();
            Refresh();
            this.DataContext = this;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Product prAdd = new Product();
            NavigationService.Navigate(new ProductAddPage(prAdd));
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (productsLv.SelectedItem != null)
                NavigationService.Navigate(new ProductAddPage(productsLv.SelectedItem as Product));
        }

        public void Refresh()
        {
            productTypes = new List<ProductType>(DBConnection.demo.ProductType);
            products = new List<Product>(DBConnection.demo.Product);
            //сортировка по стоимости
            if (costCb.SelectedItem != null)
            {
                if (costCb.SelectedIndex == 0)
                    products.Sort((p1, p2) => p1.MinCostForAgent.CompareTo(p2.MinCostForAgent));
                else if (costCb.SelectedIndex == 1)
                    products.Sort((p1, p2) => p2.MinCostForAgent.CompareTo(p1.MinCostForAgent));
                else
                    products = new List<Product>(DBConnection.demo.Product);
            }
            //сортировка по наименованию
            if (serchTb.Text != "")
                products = products.Where(p => p.Title.ToLower().StartsWith(serchTb.Text.ToLower().Trim())).ToList();
            //сортировка по типу товара
            if (typeCb.SelectedItem != null)
            {
                var typeProduct = typeCb.SelectedItem as ProductType;
                products = products.Where(i=> i.ProductTypeID == typeProduct.ID).ToList();
            }

            productsLv.ItemsSource = products;
        }

        private void costCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void serchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void typeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
