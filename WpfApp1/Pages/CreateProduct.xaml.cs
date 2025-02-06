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
using WpfApp1.DB;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Page
    {
        public CreateProduct()
        {
            InitializeComponent();

            ProductTypeTB.ItemsSource = DBConnection.DB.ProductType.ToList();
            ProductTypeTB.SelectedIndex = 1;
            ProductTypeTB.DisplayMemberPath = "Title";
            ProductTypeTB.SelectedValuePath = "ID";
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
           
                if (TitleTB.Text == "" || ArticleNumberTB.Text == "" || ProductionPersonCountTB.Text == "" || ProductionWorkshopNumberTB.Text == "" || MinCostForAgentTB.Text == "" || DescriptionTB.Text == "")
                {
                    MessageBox.Show("Все поля должны быть заполнены!");
                    return;
                }

                int productionPersonCount;

                if (!int.TryParse(ProductionPersonCountTB.Text, out productionPersonCount))
                {
                    MessageBox.Show("Количество человек для производства должно быть числом!");
                    return;
                }

                int productionWorkshopNumber;

                if (!int.TryParse(ProductionWorkshopNumberTB.Text, out productionWorkshopNumber))
                {
                    MessageBox.Show("Номер производственного цеха должен быть числом!");
                    return;
                }

                int minCostForAgent;

                if (!int.TryParse(MinCostForAgentTB.Text, out minCostForAgent))
                {
                    MessageBox.Show("Минимальная стоимость для агента должна быть числом!");
                    return;
                }

                Product product = new Product();
                product.Title = TitleTB.Text;
                product.ArticleNumber = ArticleNumberTB.Text;
                product.Description = DescriptionTB.Text;

                var productType = DBConnection.DB.ProductType.Where(p => p.Title == ProductTypeTB.Text).First();

                product.ProductionPersonCount = productionPersonCount;
                product.ProductionWorkshopNumber = productionWorkshopNumber;
                product.MinCostForAgent = minCostForAgent;
                product.ProductType = productType;


                DBConnection.DB.Product.Add(product);
                DBConnection.DB.SaveChanges();

                NavigationService.Navigate(new ProductsPage());
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
