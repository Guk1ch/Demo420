using SochnevDemoApp.Models;
using SochnevDemoApp.Windows;
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

namespace SochnevDemoApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        private List<Product> AllProducts { get; set; }
        private List<ProductType> AllTypes { get; set; }
        public ProductListPage()
        {
            InitializeComponent();
            AllProducts = App.db.Product.ToList();
            AllTypes = App.db.ProductType.ToList();
            AllTypes.Insert(0, new ProductType() { Title = "Все типы" });
            FilterCb.ItemsSource = AllTypes;
            FilterCb.DisplayMemberPath = "Title";
            FilterCb.SelectedIndex = 0;
            SortCb.SelectedIndex = 0;
            Refresh();
        }

        private void Refresh()
        {
            List<Product> filterList = AllProducts;
            string searchText = SearchTb.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filterList = filterList.Where(x => x.Title.ToLower().Contains(searchText) || x.Description.ToLower().Contains(searchText)).ToList();
            }
            if (SortCb.SelectedIndex == 0)
            {
                filterList = filterList.OrderBy(x => x.Title).ToList();
            }
            if (SortCb.SelectedIndex == 1)
            {
                filterList = filterList.OrderByDescending(x => x.Title).ToList();
            }
            if (SortCb.SelectedIndex == 2)
            {
                filterList = filterList.OrderBy(x => x.ProductionWorkshopNumber).ToList();
            }
            if (SortCb.SelectedIndex == 3)
            {
                filterList = filterList.OrderByDescending(x => x.ProductionWorkshopNumber).ToList();
            }
            if (SortCb.SelectedIndex == 4)
            {
                filterList = filterList.OrderBy(x => x.MinCostForAgent).ToList();
            }
            if (SortCb.SelectedIndex == 5)
            {
                filterList = filterList.OrderByDescending(x => x.MinCostForAgent).ToList();
            }
            if(FilterCb.SelectedIndex > 0)
            {
                ProductType productType = FilterCb.SelectedItem as ProductType;
                filterList = filterList.Where(x => x.ProductTypeID == productType.ID).ToList();
            }
            ProductList.ItemsSource = filterList;
        }


        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            AddEditProductWindow addEditProductWindow = new AddEditProductWindow(product);
            addEditProductWindow.ShowDialog();
            Refresh();
        }

        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = ProductList.SelectedItem as Product;
            AddEditProductWindow addEditProductWindow = new AddEditProductWindow(product);
            addEditProductWindow.ShowDialog();
            Refresh();
        }
    }
}
