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
using VosmerkaApp.DB;

namespace VosmerkaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        Product productSel;
        public AddProductPage(Product product)
        {
            InitializeComponent();
            productSel = product;
            List<String> products = new List<String>();

            foreach (ProductType type in DB.Connection.db.ProductType){
                products.Add(type.Title);
            }
            
            TypeCb.ItemsSource = products;

            if (productSel.ID != 0) 
            {
                DeleteBtn.Visibility = Visibility.Visible;
                MinimumCost.Text = productSel.MinCostForAgent.ToString();
                Art.Text = productSel.ArticleNumber;
                productSel.Description = Description.Text;
                MinimumCost.Text = productSel.MinCostForAgent.ToString();
                Count.Text = productSel.ProductionPersonCount.ToString();
            }

            
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные сохранены");
            NavigationService.GoBack();

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            productSel.MinCostForAgent = int.Parse(MinimumCost.Text);
            productSel.ArticleNumber = Art.Text;
            productSel.Description = Description.Text;
            productSel.ProductionWorkshopNumber = int.Parse(Number.Text);
            productSel.ProductionPersonCount = int.Parse(Count.Text);
            productSel.ProductTypeID = TypeCb.SelectedIndex+1;
            if (productSel.ID != 0)
            {
                DB.Connection.db.SaveChanges();
            }
            DB.Connection.db.Product.Add(productSel);
            DB.Connection.db.SaveChanges();
            MessageBox.Show("Данные сохранены");
            NavigationService.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
