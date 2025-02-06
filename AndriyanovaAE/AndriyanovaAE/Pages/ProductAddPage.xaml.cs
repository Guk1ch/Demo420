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
using AndriyanovaAE.DB;
using Microsoft.Win32;

namespace AndriyanovaAE.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductAddPage.xaml
    /// </summary>
    public partial class ProductAddPage : Page
    {
        public List<ProductType> productTypes {  get; set; }
        public Product contextProduct;
        public ProductAddPage(Product product)
        {
            InitializeComponent();
            productTypes = new List<ProductType>(DBConnection.demo.ProductType);
            DataContext = contextProduct=  product;
            if (contextProduct.ID != 0)
            {
                titleTb.Text = contextProduct.Title;
                
                articleTb.Text=contextProduct.ArticleNumber ;
                costTb.Text= contextProduct.MinCostForAgent.ToString();
                personCountTb.Text= contextProduct.ProductionPersonCount.ToString();
                numberWorkShopTb.Text = contextProduct.ProductionWorkshopNumber.ToString();
                
            }
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = typeCb.SelectedItem as ProductType;
            //проверка на заполнение полей
            if (articleTb.Text.Trim()=="" || costTb.Text.Trim() == "" || numberWorkShopTb.Text.Trim() == "" || personCountTb.Text.Trim() == "" || titleTb.Text.Trim()=="" || type == null)
                MessageBox.Show("Заполните все поля!","", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                try
                {
                    //сохранение данных в БД
                    contextProduct.Title = titleTb.Text.Trim();
                    contextProduct.ProductTypeID = type.ID;
                    contextProduct.ArticleNumber = articleTb.Text.Trim();
                    contextProduct.MinCostForAgent = int.Parse(costTb.Text.Trim());
                    contextProduct.ProductionPersonCount = int.Parse(personCountTb.Text.Trim());
                    contextProduct.ProductionWorkshopNumber = int.Parse(numberWorkShopTb.Text.Trim());

                    if (contextProduct.ID == 0)
                        DBConnection.demo.Product.Add(contextProduct);
                    DBConnection.demo.SaveChanges();

                    MessageBox.Show("Вы внесли изменения в список продукции", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new ProductsPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void photoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = " .png; .jpg; .jpeg | *.png; *.jpg; *.jpeg" };
                if (openFileDialog.ShowDialog().GetValueOrDefault())
                {
                    contextProduct.Photo = File.ReadAllBytes(openFileDialog.FileName);
                    img.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
