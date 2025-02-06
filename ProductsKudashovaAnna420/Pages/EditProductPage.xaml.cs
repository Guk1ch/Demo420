using ProductsKudashovaAnna420.DB;
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

namespace ProductsKudashovaAnna420.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        public static List<Product> products { get; set; }
        public static List<ProductType> productTypes { get; set; }

        Product contextProduct;
        public EditProductPage(Product product)
        {
            InitializeComponent();

            contextProduct = product;
            products = new List<Product>(DBConnection.productsDemo.Product.ToList());
            productTypes = new List<ProductType>(DBConnection.productsDemo.ProductType.ToList());

            NameTbx.Text = contextProduct.Title;

            ProductTypeCbx.SelectedItem = contextProduct.ProductType;


            PhotoProduct.Source = new BitmapImage(new Uri(product.Image, UriKind.Relative));
            ArticleTbx.Text = contextProduct.ArticleNumber;
            DescriptonTbx.Text = contextProduct.Description;
            ProductionPersonCountTbx.Text = (contextProduct.ProductionPersonCount).ToString();
            ProductionWorkshopNumberTbx.Text = (contextProduct.ProductionWorkshopNumber).ToString();
            MinCostForAgentTbx.Text = (contextProduct.MinCostForAgent).ToString();


            this.DataContext = this;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); 
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Product product = contextProduct;   

                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(ArticleTbx.Text) == null)
                {
                    error.AppendLine("Заполните необходимые поля!");
                }

                else
                {
                    product.Title = NameTbx.Text.Trim();

                    var a = ProductTypeCbx.SelectedItem as ProductType;
                    product.ProductTypeID = a.ID;

                    product.ArticleNumber = ArticleTbx.Text.Trim();
                    product.Description = DescriptonTbx.Text.Trim();

                    product.ProductionPersonCount = int.Parse(ProductionPersonCountTbx.Text.Trim());
                    product.ProductionWorkshopNumber = int.Parse(ProductionWorkshopNumberTbx.Text.Trim());
                    product.MinCostForAgent = int.Parse(MinCostForAgentTbx.Text.Trim());

                    DBConnection.productsDemo.SaveChanges();


                    NameTbx.Text = String.Empty;
                    ProductTypeCbx.Text = String.Empty;
                    ArticleTbx.Text = String.Empty;
                    DescriptonTbx.Text = String.Empty;
                    ProductionPersonCountTbx.Text = String.Empty;
                    ProductionWorkshopNumberTbx.Text = String.Empty;
                    MinCostForAgentTbx.Text = String.Empty;

                    DBConnection.productsDemo.SaveChanges();

                    NavigationService.Navigate(new AllProductsPage());
                }
            }

            catch

            {
                MessageBox.Show("Введите корректно. Ошибка");
            }
        }

        private void EditPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Filter = "Image Files | *.png; *.jpeg; *.jpg; *.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = $"/products/{openFileDialog.SafeFileName}";
                PhotoProduct.Source = new BitmapImage(new Uri(selectedImagePath, UriKind.Relative));
                contextProduct.Image = selectedImagePath;
            }
        }
    }
}
