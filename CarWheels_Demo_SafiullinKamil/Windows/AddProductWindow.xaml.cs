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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();

            ProductTypeCb.ItemsSource = App.db.ProductType.ToList();
        }

        private void TextBoxInt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            var fieldsToCheck = new[] { TitleTb.Text, ArticleTb.Text, PersonCountTb.Text, WorkShopNumberTb.Text, CostTb.Text, DescriptionTb.Text };
            if (fieldsToCheck.Any(string.IsNullOrWhiteSpace) || ProductTypeCb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля.");
            }
            else
            {
                if (ArticleTb.Text.Length > 6)
                {
                    MessageBox.Show("Артикул должен состоять из 6 символов.");
                    return;
                }

                Product product = new Product()
                {
                    Title = TitleTb.Text,
                    ProductTypeID = (ProductTypeCb.SelectedItem as ProductType).ID,
                    ArticleNumber = ArticleTb.Text,
                    ProductionPersonCount = int.Parse(PersonCountTb.Text),
                    ProductionWorkshopNumber = int.Parse(WorkShopNumberTb.Text),
                    MinCostForAgent = int.Parse(CostTb.Text),
                    Description = DescriptionTb.Text,
                };

                App.db.Product.Add(product);
                App.db.SaveChanges();

                MessageBox.Show("Продукт успешно добавлен.");
                Close();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
