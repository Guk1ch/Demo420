using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Vosmerka.DB;

namespace Vosmerka.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public static List<Product> products {  get; set; }
        public static Product product1 = new Product();
        public AddProductPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainHomePage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTb.Text == "" || ArticleNumberTb.Text == "" || TestImg.Source == null)
            {
                MessageBox.Show("Заполните все данные!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                product1.Title = TitleTb.Text;
                product1.ArticleNumber = ArticleNumberTb.Text;
                product1.MinCostForAgent = Convert.ToDecimal(MinCostForAgentTb.Text);
                DBConnection.Vosmerka.Product.Add(product1);
                DBConnection.Vosmerka.SaveChanges();
                MessageBox.Show("Продукт добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new MainHomePage());
            }
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                product1.PhotoBinary = File.ReadAllBytes(openFileDialog.FileName);
                TestImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            };
        }
    }
}
