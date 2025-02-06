using Demo_Podgotovka_Mukachev.DB;
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

namespace Demo_Podgotovka_Mukachev.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListProductPage.xaml
    /// </summary>
    public partial class ListProductPage : Page
    {
        private Product product;
        public ListProductPage()
        {
            InitializeComponent();
            ProductLv.ItemsSource = App.db.Product.Where(x => x.IsActive == true).ToList();
        }

        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductDelete(object sender, RoutedEventArgs e)
        {
            if (ProductLv.SelectedIndex != -1)
            {
                product = (Product)ProductLv.SelectedItem;
                product.IsActive = false;
                App.db.SaveChanges();
                MessageBox.Show("Продукция удалена");
                NavigationService.Navigate(new ListProductPage());
            }
            else
            {
                MessageBox.Show("Вы не выбрали сотрудника для удаления!");

            }
        }

        private void ProductAdd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductCRUDPage());
        }
    }
}
