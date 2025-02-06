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
using EightZagirov420.DB;
using EightZagirov420.Models;

namespace EightZagirov420.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public static List<Product> products { get; set; }
        public static List<ProductType> productTypes { get; set; }  

        public static List<Material> materials { get; set; }
        public ProductPage()
        {
            InitializeComponent();
            ProductLV.ItemsSource = new List<Product>(DBConnection.eight.Product.ToList());
            this.DataContext = this;
        }

        private void ProductLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductLV.SelectedItem is Product product)
            {
                product = ProductLV.SelectedItem as  Product;
                NavigationService.Navigate(new EditPage(product));
            }

        }

        

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            ProductLV.ItemsSource = DBConnection.eight.Product.ToList();

            var filterProduct = DBConnection.eight.Product.AsQueryable(); // Измените ToList() на AsQueryable()

            if (!string.IsNullOrWhiteSpace(SearchTbx.Text)) // Используйте IsNullOrWhiteSpace для проверки на пустоту
            {
                string searchText = SearchTbx.Text.Trim().ToLower(); // Извлеките текст поиска один раз

                filterProduct = filterProduct.Where(i => i.Title.ToLower().StartsWith(searchText));
            }


            var selectedTypeProduct = TypeProductCB.SelectedItem as ProductType;
            if (selectedTypeProduct != null && TypeProductCB.SelectedIndex !=0) {
                filterProduct = filterProduct.Where(x => x.ProductType == filterProduct);
            }
            switch (SortCb.SelectedIndex)
            {
                case 1:
                    filterProduct = filterProduct.OrderBy(x => x.MinCostForAgent);
                    break;
                case 2:
                    filterProduct = filterProduct.OrderByDescending(x => x.MinCostForAgent);
                    break;
                default:
                    // Если нужна сортировка по умолчанию, добавьте сюда.
                    // Пример: filterProduct = filterProduct.OrderBy(x => x.Title);
                    break;
            }

                    ProductLV.ItemsSource = filterProduct.ToList();
        }

        



        private void TypeProductCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }
    }
}
