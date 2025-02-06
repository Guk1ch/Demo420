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
using Vosmerka.DB;

namespace Vosmerka.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainHomePage.xaml
    /// </summary>
    public partial class MainHomePage : Page
    {
        public static List<Product> products {  get; set; }
        public MainHomePage()
        {
            InitializeComponent();
            ProductLV.ItemsSource = new List<Product>(DBConnection.Vosmerka.Product.ToList());
            this.DataContext = this;
            //List<Product> clients = DBConnection.Vosmerka.Product.ToList();
            //foreach (Product client in clients)
            //{

            //    // Укажите путь к изображению в ресурсах, используя тот же стиль, что и выше
            //    string relativePath = $"pack://application:,,,/Vosmerka;component/{client.Image}";
            //    BitmapImage bitmap = new BitmapImage(new Uri(relativePath, UriKind.Absolute));
            //    // Сохраняем изображение в MemoryStream
            //    MemoryStream stream = new MemoryStream();
            //    BitmapEncoder encoder = new JpegBitmapEncoder();
            //    encoder.Frames.Add(BitmapFrame.Create(bitmap));
            //    encoder.Save(stream);
            //    client.PhotoBinary = stream.ToArray();
            //    DBConnection.Vosmerka.SaveChanges();
            //}
        }

        private void NameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filterProduct = DBConnection.Vosmerka.Product.ToList();
            if (NameTb.Text.Length > 0)
            {
                filterProduct = filterProduct.Where(i => i.Title.ToLower().StartsWith(NameTb.Text.Trim().ToLower())).ToList();
            }
            ProductLV.ItemsSource = filterProduct;
        }

        private void ProductLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductLV.SelectedItem is Product product)
            {
                product = ProductLV.SelectedItem as Product;
                NavigationService.Navigate(new EditProductPage(product));
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Product product)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        DBConnection.Vosmerka.Product.Remove(product);
                        DBConnection.Vosmerka.SaveChanges();
                        NavigationService.Navigate(new MainHomePage());
                        MessageBox.Show("Товар успешно удалён!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Товар невозможно удалить, так как он находится в рассписании", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            var filterProduct = DBConnection.Vosmerka.Product.ToList();
            switch (SortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    filterProduct = filterProduct.OrderBy(x => x.MinCostForAgent).ToList();
                    break;
                case 2:
                    filterProduct = filterProduct.OrderBy(x => -x.MinCostForAgent).ToList();
                    break;

                default:
                    break;
            }
            ProductLV.ItemsSource = filterProduct;
        }

    }
}
