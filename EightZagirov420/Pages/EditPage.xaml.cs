using EightZagirov420.DB;
using EightZagirov420.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace EightZagirov420.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public static List<Product> products { get; set; }
        Product contextProduct;
        public static Product Product1 = new Product();
        public static Product pro { get; set; }
        public EditPage(Product product)
        {
            InitializeComponent();
            contextProduct = product;
            pro = product;
            ArticleTbx.Text = Convert.ToString(contextProduct.ArticleNumber);
            NameTbx.Text = Convert.ToString(contextProduct.Title);
            CountForProisvoTbx.Text = Convert.ToString(contextProduct.ProductionPersonCount);
            NumberChexTbx.Text = Convert.ToString(contextProduct.ProductionWorkshopNumber);
            MinCostAgentTbx.Text = Convert.ToString(contextProduct.MinCostForAgent);
            this.DataContext = this;



        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = Product1;
            if (ArticleTbx.Text == "" || NameTbx.Text == "" || CountForProisvoTbx.Text == "" || NumberChexTbx.Text == "" || MinCostAgentTbx.Text == null)
            {
                MessageBox.Show("Заполните все данные!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                product.ArticleNumber = ArticleTbx.Text;
                product.Title = NameTbx.Text;
                product.ProductionPersonCount = Convert.ToInt32(CountForProisvoTbx.Text);
                product.ProductionWorkshopNumber = Convert.ToInt32(NumberChexTbx.Text);
                DBConnection.eight.SaveChanges();
                MessageBox.Show("Данные изменены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ProductPage());

            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
