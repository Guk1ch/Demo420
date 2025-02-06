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
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {
        public EnterPage()
        {
            InitializeComponent();
        }

        private void Button_Click_ProductList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProductPage());
        }

        private void Button_Click_MaterialList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MaterialPage());
        }

        private void Button_Click_OrderList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.OrderPage());
        }
    }
}
