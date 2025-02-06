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
using AndriyanovaAE.DB;

namespace AndriyanovaAE.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class MaterialsPage : Page
    {
        public List<Material> materials {  get; set; }
        public MaterialsPage()
        {
            InitializeComponent();
            materials = new List<Material>(DBConnection.demo.Material);
            materialsLv.ItemsSource = materials;
            this.DataContext = materials;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
