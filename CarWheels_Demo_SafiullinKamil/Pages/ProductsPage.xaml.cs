using CarWheels_Demo_SafiullinKamil.Models;
using CarWheels_Demo_SafiullinKamil.Windows;
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

namespace CarWheels_Demo_SafiullinKamil.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private MainWindow _mainWindow;
        public static List<Product> products = new List<Product>();
        public static List<Product> filterProducts = new List<Product>();
        public ProductsPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            products = App.db.Product.ToList();
            ProductsLv.ItemsSource = products;

            List<ProductType> productTypes = App.db.ProductType.ToList();
            productTypes.Insert(0, new ProductType { Title = "Все продукты"});
            FiltrationCb.ItemsSource = productTypes;
            FiltrationCb.SelectedIndex = 0;
        }

        private void Refresh()
        {
            filterProducts = products;
            if (!string.IsNullOrWhiteSpace(SearchTb.Text))
            {
                string searchText = SearchTb.Text.Trim().ToLower();
                filterProducts = filterProducts.Where(x => x.Title.Trim().ToLower().Contains(searchText)).ToList();
            }
            if (FiltrationCb.SelectedIndex > 0)
            {
                filterProducts = filterProducts.OrderBy(x => x.ProductTypeID == (FiltrationCb.SelectedItem as ProductType).ID).ToList();
            }
            ProductsLv.ItemsSource = filterProducts;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void FiltrationCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
            products = App.db.Product.ToList();
            ProductsLv.ItemsSource = products;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            App.selectedProduct = (Product)button.DataContext;
            EditProductWindow editProductWindow = new EditProductWindow();
            editProductWindow.ShowDialog();
            products = App.db.Product.ToList();
            ProductsLv.ItemsSource = products;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Product product = (Product)button.DataContext;

            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить продукт?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                App.db.Product.Remove(product);
                App.db.SaveChanges();
                MessageBox.Show("Продукт успешно удален.");
            }
            else
            {
                MessageBox.Show("Отмена удаления.");
            }

            products = App.db.Product.ToList();
            ProductsLv.ItemsSource = products;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(_mainWindow));
        }
    }
}
