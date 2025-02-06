using demoExam.DB_location;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace demoExam.Pages
{
    public partial class MainPage : Page
    {
        private PankovDemo2025Entities _context = new PankovDemo2025Entities();
        private List<Product> _products;
        private int _currentPage = 1;
        private int _pageSize = 20;
        private string _searchText = "";
        private string _sortOrder = "По возрастанию";
        private int _filterTypeId = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProducts();
            LoadProductTypes();
        }

        private void LoadProducts()
        {
            _products = _context.Product.ToList();
            ApplyFilters();
        }

        private void LoadProductTypes()
        {
            var types = _context.ProductType.ToList();
            FilterComboBox.Items.Clear();
            FilterComboBox.Items.Add(new ComboBoxItem { Content = "Все типы" });
            foreach (var type in types)
            {
                FilterComboBox.Items.Add(new ComboBoxItem { Content = type.Title, Tag = type.ID });
            }
            FilterComboBox.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            var filteredProducts = _products
                .Where(p => p.Title.Contains(_searchText) || p.Description.Contains(_searchText))
                .Where(p => _filterTypeId == 0 || p.ProductTypeID == _filterTypeId)
                .ToList();

            switch (_sortOrder)
            {
                case "По возрастанию":
                    filteredProducts = filteredProducts.OrderBy(p => p.Title).ToList();
                    break;
                case "По убыванию":
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Title).ToList();
                    break;
            }

            DgProducts.ItemsSource = filteredProducts.Skip((_currentPage - 1) * _pageSize).Take(_pageSize);
            PageNumberTextBlock.Text = $"Страница {_currentPage} из {Math.Ceiling((double)filteredProducts.Count / _pageSize)}";
            PrevPageButton.IsEnabled = _currentPage > 1;
            NextPageButton.IsEnabled = _currentPage < Math.Ceiling((double)filteredProducts.Count / _pageSize);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = SearchTB.Text;
            _currentPage = 1;
            ApplyFilters();
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _sortOrder = (SortComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            ApplyFilters();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = FilterComboBox.SelectedItem as ComboBoxItem;
            _filterTypeId = selectedItem.Tag != null ? (int)selectedItem.Tag : 0;
            _currentPage = 1;
            ApplyFilters();
        }

        private void PrevPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            ApplyFilters();
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            ApplyFilters();
        }

        private void DgProducts_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var product = e.Row.DataContext as Product;
            if (product != null)
            {
                var lastSale = _context.ProductSale
                    .Where(ps => ps.ProductID == product.ID)
                    .OrderByDescending(ps => ps.SaleDate)
                    .FirstOrDefault();

                if (lastSale == null || lastSale.SaleDate < DateTime.Now.AddMonths(-1))
                {
                    e.Row.Background = new SolidColorBrush(Colors.LightCoral);
                }
            }
        }
    }
}