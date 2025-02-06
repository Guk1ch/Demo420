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

namespace VosmerkaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MaterialListPage.xaml
    /// </summary>
    public partial class MaterialListPage : Page
    {
        public MaterialListPage()
        {
            InitializeComponent();
            ProductLv.ItemsSource = DB.Connection.db.Material.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
