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
using Vosmerka8_Demo_Safiullin.DB;

namespace Vosmerka8_Demo_Safiullin.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRedactPage.xaml
    /// </summary>
    public partial class AddRedactPage : Page
    {
        public Product product1;
        
        public AddRedactPage(Product product)
        {
            InitializeComponent();
            
            
            product1 = product;
            Title.Text = product.Title;
            Article.Text = product.ArticleNumber;
            Disc.Text = product.Description;
            MinCost.Text = product.MinCostForAgent.ToString();
            
            
            
            
            
        
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            product1.Title = Title.Text;
            product1.ArticleNumber = Article.Text;
            product1.Description = Disc.Text;
            App.vosmerka.SaveChanges();
            MessageBox.Show("Успешно сохранил, проверяйте");
            NavigationService.Navigate(new MainPage());
            
        }
    }
}
