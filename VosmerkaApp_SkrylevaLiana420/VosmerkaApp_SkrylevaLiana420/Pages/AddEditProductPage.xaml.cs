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
using VosmerkaApp_SkrylevaLiana420.DB;

namespace VosmerkaApp_SkrylevaLiana420.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        public AddEditProductPage()
        {
            InitializeComponent();
            TypeCB.ItemsSource = Connection.db.ProductType.ToList();
            MaterialCB.ItemsSource = Connection.db.Material.ToList();
            try
            {
                if (App.selectedProduct != null)
                {
                    NameTB.Text = App.selectedProduct.Title;
                    TypeCB.SelectedItem = App.selectedProduct.ProductType;
                    ArticleTB.Text = App.selectedProduct.ArticleNumber;
                    DescriptionTB.Text = App.selectedProduct.Description;
                    CountTB.Text = App.selectedProduct.ProductionPersonCount.ToString();
                    NumCexTB.Text = App.selectedProduct.ProductionWorkshopNumber.ToString();
                    CostTB.Text = App.selectedProduct.MinCostForAgent.ToString();
                    addBTN.Visibility = Visibility.Hidden;
                    editBTN.Visibility = Visibility.Visible;
                    MaterialsLV.ItemsSource = Connection.db.ProductMaterial.Where(i => i.ProductID == App.selectedProduct.ID).ToList();

                }
                else
                {
                    addBTN.Visibility = Visibility.Visible;
                    editBTN.Visibility = Visibility.Hidden;
                    delBTN.Visibility = Visibility.Hidden;
                }

            }
            catch {
                MessageBox.Show("Ошибка");
            }
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            if(NameTB.Text.Length != 0 &&
            TypeCB.SelectedItem != null &&
            ArticleTB.Text.Length != 0 &&
            DescriptionTB.Text.Length != 0 &&
            CountTB.Text.Length != 0 &&
            NumCexTB.Text.Length != 0 &&
            CostTB.Text.Length != 0)
            {
                Product product = new Product();
                product.Title = NameTB.Text;
                product.Description = DescriptionTB.Text;
                product.ProductTypeID = (TypeCB.SelectedItem as ProductType).ID;
                product.ArticleNumber = ArticleTB.Text;
                product.ProductionPersonCount = int.Parse(CountTB.Text);
                product.ProductionWorkshopNumber = int.Parse(NumCexTB.Text);
                product.MinCostForAgent = decimal.Parse(CostTB.Text);
                
                Connection.db.Product.Add(product);
                if (MaterialCB.SelectedItem != null)
                {
                    ProductMaterial material = new ProductMaterial();
                    material.ProductID = product.ID;
                    material.MaterialID = (MaterialCB.SelectedItem as Material).ID;
                }

                Connection.db.SaveChanges();

                MessageBox.Show("Продукт успешно добавлен");
                NavigationService.Navigate(new ListProducts());
            }
            else
            {
                MessageBox.Show("Введите данные!");
            }
        }

        private void editBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text.Length != 0 &&
            TypeCB.SelectedItem != null &&
            ArticleTB.Text.Length != 0 &&
            DescriptionTB.Text.Length != 0 &&
            CountTB.Text.Length != 0 &&
            NumCexTB.Text.Length != 0 &&
            CostTB.Text.Length != 0)
            {
                App.selectedProduct.Title = NameTB.Text;
                App.selectedProduct.Description = DescriptionTB.Text;
                App.selectedProduct.ProductTypeID = (TypeCB.SelectedItem as ProductType).ID;
                App.selectedProduct.ArticleNumber = ArticleTB.Text;
                App.selectedProduct.ProductionPersonCount = int.Parse(CountTB.Text);
                App.selectedProduct.ProductionWorkshopNumber = int.Parse(NumCexTB.Text);
                App.selectedProduct.MinCostForAgent = decimal.Parse(CostTB.Text);
                if (MaterialCB.SelectedItem != null)
                {
ProductMaterial material = new ProductMaterial();
                material.ProductID = App.selectedProduct.ID ;
                material.MaterialID = (MaterialCB.SelectedItem as Material).ID;
                }
                    
                Connection.db.SaveChanges();
                MessageBox.Show("Продукт успешно изменен");
                NavigationService.Navigate(new ListProducts());
            }
            else
            {
                MessageBox.Show("Введите данные!");
            }


        }

        private void delBTN_Click(object sender, RoutedEventArgs e)
        {
            List<ProductMaterial> materials = Connection.db.ProductMaterial.Where(i => i.ProductID == App.selectedProduct.ID).ToList();
            if(materials.Count != 0)
            {
                Connection.db.Product.Remove(App.selectedProduct);
                Connection.db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Нельзя удалить");
            }
        }
    }
}
