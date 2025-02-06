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
using WpfApp1.Windows;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();

            Refresh();
        }

        public void Refresh()
        {
            ProductsTable.ItemsSource = DB.DBConnection.DB.Product.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = SearchTB.Text;

            if (search != "")
            {
                ProductsTable.ItemsSource = DB.DBConnection.DB.Product.Where(p => p.Title.Contains(search) || p.Description.Contains(search)).ToList();
            } else
            {
                Refresh();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateProduct());
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            var product = ProductsTable.SelectedItem as DB.Product;
            
            if (product == null)
            {
                MessageBox.Show("Нужно выбрать продукцию в таблице!");
                return;
            }

            (new EditProductWindow(product)).ShowDialog();
            Refresh();
        }
    }
}
