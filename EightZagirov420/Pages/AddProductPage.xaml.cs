using EightZagirov420.Models;
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
using EightZagirov420.DB;

namespace EightZagirov420.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public static List<Product> products { get; set; }
        public static Product Product1 = new Product();
        public AddProductPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = Product1;
            if (ArticleTbx.Text == "" || NameTbx.Text == "" || CountForProisvoTbx.Text == "" || NumberChexTbx.Text == "" || MinCostAgentTbx.Text == null)
            {
                MessageBox.Show("Заполните все данные!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                product.ArticleNumber = ArticleTbx.Text;
                product.Title = NameTbx.Text;
                product.ProductionPersonCount = Convert.ToInt32(CountForProisvoTbx.Text);
                product.ProductionWorkshopNumber = Convert.ToInt32(NumberChexTbx.Text);
                product.MinCostForAgent = Convert.ToInt32(MinCostAgentTbx.Text);
                DBConnection.eight.SaveChanges();
                MessageBox.Show("Продукция была добавлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ProductPage());

            }
        }
    }
}
