using Fayzullina_Elvina_Rafaelevna.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fayzullina_Elvina_Rafaelevna.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page
    {
        public ProductsListPage()
        {
            InitializeComponent();
            
            var filter = App.DB.ProductType.ToList();
            filter.Insert(0, new ProductType { Title = "Все типы" });
            CBFilter.ItemsSource = filter;
            CBFilter.SelectedIndex = 0;
            var productMaterials = App.DB.ProductMaterial.ToList();
            var materials = App.DB.Material.ToList();
            var products = App.DB.Product.ToList();

            var productList = products.Select(p => new
            {
                DisplayImage = p.DisplayImage,
                Title = p.Title,
                ProductTypeTitle = p.ProductType.Title,
                ProductType = p.ProductType,
                ArticleNumber = p.ArticleNumber,
                Description = p.Description,
                Materials = string.Join(", ", productMaterials.Where(pm => pm.ProductID == p.ID)
                                                  .Select(pm => materials.First(m => m.ID == pm.MaterialID).Title)),
                TotalCost = productMaterials.Where(pm => pm.ProductID == p.ID)
                                 .Sum(pm => materials.First(m => m.ID == pm.MaterialID).Cost * pm.Count)
            }).ToList();
            LVProducts.ItemsSource = productList;
            
        }
        private void AddBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = (sender as Button).DataContext as Product;
                App.DB.Product.Remove(product);
                App.DB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления!");
            }
        }
        private void Refresh()
        {
            // Получаем данные
            var products = App.DB.Product.ToList();
            var productMaterials = App.DB.ProductMaterial.ToList();
            var materials = App.DB.Material.ToList();

            // Формируем список продуктов
            var productList = products.Select(p => new
            {
                DisplayImage = p.DisplayImage,
                Title = p.Title,
                ProductTypeTitle = p.ProductType.Title,
                ProductType = p.ProductType,
                ArticleNumber = p.ArticleNumber,
                Description = p.Description,
                Materials = string.Join(", ", productMaterials.Where(pm => pm.ProductID == p.ID)
                                                  .Select(pm => materials.First(m => m.ID == pm.MaterialID).Title)),
                TotalCost = productMaterials.Where(pm => pm.ProductID == p.ID)
                                 .Sum(pm => materials.First(m => m.ID == pm.MaterialID).Cost * pm.Count)
            }).ToList();

            // Фильтрация по поисковому запросу
            var searchText = SearchTB.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                productList = productList.Where(x => x.Title.ToLower().Contains(searchText) && x.Description.ToLower().Contains(searchText)).ToList();
            }

            // Фильтрация по типу продукта
            var typeFilter = CBFilter.SelectedItem as ProductType;
            if (typeFilter != null && CBFilter.SelectedIndex != 0)
            {
                productList = productList.Where(x => x.ProductType == typeFilter).ToList();
            }

            // Сортировка в зависимости от выбора в ComboBox
            switch (CBSort.SelectedIndex)
            {
                case 0: // Наименование (по возрастанию)
                    productList = productList.OrderBy(p => p.Title).ToList();
                    break;
                case 1: // Наименование (по убыванию)
                    productList = productList.OrderByDescending(p => p.Title).ToList();
                    break;
                case 2: // Номер производственного цеха (по возрастанию)
                    productList = productList.OrderBy(p => p.ArticleNumber).ToList();
                    break;
                case 3: // Номер производственного цеха (по убыванию)
                    productList = productList.OrderByDescending(p => p.ArticleNumber).ToList();
                    break;
                case 4: // Минимальная стоимость (по возрастанию)
                    productList = productList.OrderBy(p => p.TotalCost).ToList();
                    break;
                case 5: // Минимальная стоимость (по убыванию)
                    productList = productList.OrderByDescending(p => p.TotalCost).ToList();
                    break;
                case 6: // Минимальная стоимость (по убыванию)
                    productList = productList.ToList();
                    break;
            }

            // Устанавливаем источник данных для ListView
            LVProducts.ItemsSource = productList;
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CBFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
