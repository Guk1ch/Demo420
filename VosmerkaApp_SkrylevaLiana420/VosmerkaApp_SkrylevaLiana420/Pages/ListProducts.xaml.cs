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
    /// Логика взаимодействия для ListProducts.xaml
    /// </summary>
    public partial class ListProducts : Page
    {
        public ListProducts()
        {
            InitializeComponent();
            ProductsLV.ItemsSource = Connection.db.Product.ToList();
            FilterCB.ItemsSource = Connection.db.ProductType.ToList();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            List<Product> serch = Connection.db.Product.Where(i => i.Title.Contains(SerchTB.Text.ToLower().ToLower()) || i.Description.Contains(SerchTB.Text.ToLower().ToLower())).ToList();
            if (!string.IsNullOrEmpty(SerchTB.Text))
            {
                ProductsLV.ItemsSource = serch;

            }
            else
            {
                ProductsLV.ItemsSource = Connection.db.Product.ToList();

            }

            if (SortCB.SelectedIndex == 1)
            {
                if (serch.Count > 0)
                {
                    ProductsLV.ItemsSource = serch.OrderByDescending(i => i.MinCostForAgent).ToList();

                }
                else
                {
                    ProductsLV.ItemsSource = Connection.db.Product.OrderByDescending(i => i.MinCostForAgent).ToList();

                }
                return;
            }
            if (SortCB.SelectedIndex == 0)
            {
                if (serch.Count > 0)
                {
                    ProductsLV.ItemsSource = serch.OrderBy(i => i.MinCostForAgent).ToList();

                }
                else
                {
                    ProductsLV.ItemsSource = Connection.db.Product.OrderBy(i => i.MinCostForAgent).ToList();

                }
                return;

            }



            ProductsLV.ItemsSource = Connection.db.Product.ToList();





        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> serch = Connection.db.Product.Where(i => i.Title.Contains(SerchTB.Text.ToLower().ToLower()) || i.Description.Contains(SerchTB.Text.ToLower().ToLower())).ToList();
            if (!string.IsNullOrEmpty(SerchTB.Text))
            {
                ProductsLV.ItemsSource = serch;

            }
            else
            {
                ProductsLV.ItemsSource = Connection.db.Product.ToList();

            }

            if (SortCB.SelectedIndex == 1)
            {
                if (serch.Count > 0)
                {
                    ProductsLV.ItemsSource = serch.OrderByDescending(i => i.MinCostForAgent).ToList();

                }
                else
                {
                    ProductsLV.ItemsSource = Connection.db.Product.OrderByDescending(i => i.MinCostForAgent).ToList();

                }
                return;
            }
            if (SortCB.SelectedIndex == 0)
            {
                if (serch.Count > 0)
                {
                    ProductsLV.ItemsSource = serch.OrderBy(i => i.MinCostForAgent).ToList();

                }
                else
                {
                    ProductsLV.ItemsSource = Connection.db.Product.OrderBy(i => i.MinCostForAgent).ToList();

                }
                return;

            }



            ProductsLV.ItemsSource = Connection.db.Product.ToList();



        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Product> serch = Connection.db.Product.Where(i => i.Title.Contains(SerchTB.Text.ToLower().ToLower()) || i.Description.Contains(SerchTB.Text.ToLower().ToLower())).ToList();
            if (!string.IsNullOrEmpty(SerchTB.Text))
            {
                ProductsLV.ItemsSource = serch;

            }
            else
            {
                ProductsLV.ItemsSource = Connection.db.Product.ToList();

            }

            if (SortCB.SelectedIndex == 1)
            {
                if (serch.Count > 0)
                {
                    ProductsLV.ItemsSource = serch.OrderByDescending(i => i.MinCostForAgent).ToList();

                }
                else
                {
                    ProductsLV.ItemsSource = Connection.db.Product.OrderByDescending(i => i.MinCostForAgent).ToList();

                }
                return;
            }
            if (SortCB.SelectedIndex == 0)
            {
                if (serch.Count > 0)
                {
                    ProductsLV.ItemsSource = serch.OrderBy(i => i.MinCostForAgent).ToList();

                }
                else
                {
                    ProductsLV.ItemsSource = Connection.db.Product.OrderBy(i => i.MinCostForAgent).ToList();

                }
                return;

            }
          
            

            ProductsLV.ItemsSource = Connection.db.Product.ToList();

            

        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage());
        }

        private void ProductsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedProduct = ProductsLV.SelectedItem as Product;
            NavigationService.Navigate(new AddEditProductPage());
        }
    }
}
