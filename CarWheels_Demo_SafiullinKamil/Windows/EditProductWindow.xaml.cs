using CarWheels_Demo_SafiullinKamil.Models;
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
using System.Windows.Shapes;

namespace CarWheels_Demo_SafiullinKamil.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public EditProductWindow()
        {
            InitializeComponent();
            Upload();

            ProductTypeCb.ItemsSource = App.db.ProductType.ToList();
        }

        private void Upload()
        {
           TitleTb.Text = App.selectedProduct.Title;
           ProductTypeCb.SelectedItem = App.selectedProduct.ProductType;
           ArticleTb.Text = App.selectedProduct.ArticleNumber;
           PersonCountTb.Text = App.selectedProduct.ProductionPersonCount.ToString();
           WorkShopNumberTb.Text = App.selectedProduct.ProductionWorkshopNumber.ToString();
           CostTb.Text = App.selectedProduct.MinCostForAgent.ToString();
           DescriptionTb.Text = App.selectedProduct.Description;
        }

        private void TextBoxInt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            var fieldsToCheck = new[] { TitleTb.Text, ArticleTb.Text, PersonCountTb.Text, WorkShopNumberTb.Text, CostTb.Text, DescriptionTb.Text };
            if (fieldsToCheck.Any(string.IsNullOrWhiteSpace) || ProductTypeCb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля.");
            }
            else if (TitleTb.Text == App.selectedProduct.Title && ArticleTb.Text == App.selectedProduct.ArticleNumber && PersonCountTb.Text == App.selectedProduct.ProductionPersonCount.ToString() && WorkShopNumberTb.Text == App.selectedProduct.ProductionWorkshopNumber.ToString() && CostTb.Text == App.selectedProduct.MinCostForAgent.ToString() && DescriptionTb.Text == App.selectedProduct.Description && ProductTypeCb.SelectedItem == App.selectedProduct.ProductType)
            {
                MessageBox.Show("Изменений не происходило.");
                return;
            }
            else
            {
                if (ArticleTb.Text.Length > 6)
                {
                    MessageBox.Show("Артикул должен состоять из 6 символов.");
                    return;
                }

                App.selectedProduct.Title = TitleTb.Text;
                App.selectedProduct.ProductTypeID = (ProductTypeCb.SelectedItem as ProductType).ID;
                App.selectedProduct.ArticleNumber = ArticleTb.Text;
                App.selectedProduct.ProductionPersonCount = int.Parse(PersonCountTb.Text);
                App.selectedProduct.ProductionWorkshopNumber = int.Parse(WorkShopNumberTb.Text);
                App.selectedProduct.MinCostForAgent = int.Parse(CostTb.Text);
                App.selectedProduct.Description = DescriptionTb.Text;

                App.db.SaveChanges();

                MessageBox.Show("Данные изменены.");
                Close();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
