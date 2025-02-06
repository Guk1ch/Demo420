using Demo_Akifev_420_P.DB;
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

namespace Demo_Akifev_420_P.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static List<Product> prod { get; set; }
        public Product product;
        public MainPage()
        {
            InitializeComponent();
            prod = App.db.Product.ToList();
            ProductsLw.ItemsSource = prod;
        }

        private void ProductsLw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            product = ProductsLw.SelectedItem as Product;
            NavigationService.Navigate(new EditPage());

        }
    }
}
