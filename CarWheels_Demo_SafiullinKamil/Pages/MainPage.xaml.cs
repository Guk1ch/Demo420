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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private MainWindow _mainWindow;
        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage(_mainWindow));
        }

        private void MaterialsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaterialsPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Close();
        }
    }
}
