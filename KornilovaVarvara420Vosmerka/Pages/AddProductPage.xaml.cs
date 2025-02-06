using KornilovaVarvara420Vosmerka.DB;
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

namespace KornilovaVarvara420Vosmerka.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public static List<Product> products {  get; set; }
        public static List<ProductType> productsType { get; set; }
        public static Product product = new Product();

        public AddProductPage()
        {
            InitializeComponent();
            products = new List<Product>(DBConnection.vosmerkaEntities.Product.ToList());
            productsType = new List<ProductType>(DBConnection.vosmerkaEntities.ProductType.ToList());
            ProdTypeCB.ItemsSource = productsType;
            this.DataContext = this;
        }

        private void OKBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                product.Title = TitleTB.Text;
                product.ProductTypeID = (ProdTypeCB.SelectedItem as ProductType).ID;
                product.ArticleNumber = ArticleNumTB.Text;
                product.Description = DescriptTB.Text;
                product.Image = "";
                product.ProductionPersonCount = Convert.ToInt16(ProductionPersonCountTB.Text);
                product.ProductionWorkshopNumber = Convert.ToInt16(ProductionWorkshopNumberTB.Text);
                product.MinCostForAgent = Convert.ToDecimal(MinCostForAgentTB.Text);

                DBConnection.vosmerkaEntities.Product.Add(product);
                DBConnection.vosmerkaEntities.SaveChanges();
                NavigationService.Navigate(new ProductionViewPage());
            }
            catch 
            {
                MessageBox.Show("Возникла ошибка!");
            }
        }

        private void NoBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductionViewPage());
        }
    }
}
