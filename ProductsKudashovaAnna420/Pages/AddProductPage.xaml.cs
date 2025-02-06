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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public static List<Product> products { get; set; }
        public static List<ProductType> productTypes { get; set; }

        public static Product product = new Product();
        public AddProductPage()
        {
            InitializeComponent();

            products = new List<Product>(DBConnection.productsDemo.Product.ToList());
            productTypes = new List<ProductType>(DBConnection.productsDemo.ProductType.ToList());


            this.DataContext = this;
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Filter = "Image Files | *.png; *.jpeg; *.jpg; *.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = $"/products/{openFileDialog.SafeFileName}";
                PhotoProduct.Source = new BitmapImage(new Uri(selectedImagePath, UriKind.Relative));
                product.Image = selectedImagePath;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                StringBuilder error = new StringBuilder();

                if (string.IsNullOrWhiteSpace(ArticleTbx.Text) == null || string.IsNullOrWhiteSpace(NameTbx.Text) == null || string.IsNullOrWhiteSpace(ProductionPersonCountTbx.Text) == null)
                {
                    error.AppendLine("Заполните необходимые поля!");
                }

                if (int.Parse(MinCostForAgentTbx.Text) >= 0)
                {
                    error.AppendLine("Стоимость должна быть больше нуля!");
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


                    DBConnection.productsDemo.Product.Add(product);
                    DBConnection.productsDemo.SaveChanges();

                    NavigationService.Navigate(new AllProductsPage());
                }
            }

            catch 

            {
                MessageBox.Show("Введите корректно. Ошибка");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllProductsPage());
        }
    }
}
