using ProductStoreEgor.Database;
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

namespace ProductStoreEgor.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public Product product = new Product();
        public ProductPage()
        {
            InitializeComponent();
            ProductLV.ItemsSource = App.db.Product.ToList();
        }


        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EnterPage());
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (ProductLV.SelectedIndex != -1)
            {
                product = (Product)ProductLV.SelectedItem;
                App.db.Product.Remove(product); 
                App.db.SaveChanges();
                MessageBox.Show($"Продукт успешно удалён");
                NavigationService.Navigate(new Pages.ProductPage());
            }
            else
            {
                MessageBox.Show("Вы не выбрали продукт для удаления!");

            }
        }
    }
}
