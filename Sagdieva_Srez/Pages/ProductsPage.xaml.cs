using System;
using System.Collections.Generic;
using System.Data;
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
using Sagdieva_Srez.DB;
using Sagdieva_Srez.Windowss;

namespace Sagdieva_Srez.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public static List<Product> products {  get; set; }
        public static List<Material> materials { get; set; }
        public static List<ProductType> productTypes { get; set; }

        public ProductsPage()
        {
            InitializeComponent();
            products = DBConnection.srez.Product.ToList();
            materials = DBConnection.srez.Material.ToList();
            productTypes = DBConnection.srez.ProductType.ToList();


            this.DataContext = this;
            Refresh();
        }

        private void Refresh()
        {
            ProductsLV.ItemsSource = DBConnection.srez.Product.ToList();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();
            Refresh();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsLV.SelectedItem is Product product)
            {
                MessageBoxResult result = MessageBox.Show("Изменить продукт?", "Подтвердите действия", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DBConnection.editProduct = ProductsLV.SelectedItem as Product;
                    EditProductWindow editProductWindow = new EditProductWindow(product);
                    editProductWindow.ShowDialog();
                }
                else { Refresh(); }
            }
            else if (ProductsLV.SelectedItem is null)
            {
                MessageBox.Show("Выберите продукт!");
            }
            Refresh();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsLV.SelectedItem is Product product)
            {
                MessageBoxResult result = MessageBox.Show("Удалить продукт?", "Подтвердите действия", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DBConnection.srez.Product.Remove(product);
                    DBConnection.srez.SaveChanges();
                    MessageBox.Show("Продукт удален.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
                else { Refresh(); }
            }
            else if (ProductsLV.SelectedItem is null)
            {
                MessageBox.Show("Выберите продукт!");
            }
            Refresh();
            
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTB.Text.Length > 0)

                ProductsLV.ItemsSource = DBConnection.srez.Product.Where(i => i.Title.ToLower().StartsWith(SearchTB.Text.Trim().ToLower())).ToList();

            else
                Refresh();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = SortCB.SelectedItem as ProductType;

            if (selectedType != null && SortCB.SelectedIndex != 0)
            {
                ProductsLV.ItemsSource = products.Where(x => x.ProductTypeID == selectedType.ID).ToList();
            }
            else
            {
                Refresh();
            }
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
