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
using WpfApp1.DB;
using static WpfApp1.pages.ProductsList;

namespace WpfApp1.pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsList.xaml
    /// </summary>
    public partial class ProductsList : Page
    {

        public int pageNum = 1;
        public class LVProduct
        {
            public int id {  get; set; }
            public string Name { get; set; }
            public string TypeName { get; set; }
            public string Article { get; set; }
            public string Materials { get; set; }
            public string Cost { get; set; }
            public string Image { get; set; }

            public LVProduct (string name, string typeName, string article, string materials, string cost, string image, int id)
            {
                id = id;
                Name = name;
                TypeName = typeName;
                Article = article;
                Materials = materials;
                Cost = cost;
                Image = image;
            }
        }

        public class FilterByVariant
        {
            public int id;
            public string name;

            public FilterByVariant (int id, string name)
            {
                this.id = id;
                this.name = name;
            }

            public override string ToString()
            {
                return this.name;
            }
        }

        void setProducts ()
        {
            List<LVProduct> lVProducts = new List<LVProduct>();
            List<Product> products = App.db.Product.ToList();

            if (sortByCB.SelectedIndex >= 0)
            {
                switch (sortByCB.SelectedIndex)
                {
                    case 0:
                        products.Sort((p1, p2) => -String.Compare(p1.Title, p2.Title,
                            comparisonType: StringComparison.OrdinalIgnoreCase));
                        break;
                    case 1:
                        products.Sort((p1, p2) => String.Compare(p1.Title, p2.Title,
                            comparisonType: StringComparison.OrdinalIgnoreCase));
                        break;
                    case 2:
                        products.Sort((p1, p2) => p1.ProductionWorkshopNumber ?? 0 - p2.ProductionWorkshopNumber ?? 0);
                        break;
                    case 3:
                        products.Sort((p1, p2) => p2.ProductionWorkshopNumber ?? 0 - p1.ProductionWorkshopNumber ?? 0);
                        break;
                    case 4:
                        products.Sort((p1, p2) => int.Parse((p1.MinCostForAgent - p2.MinCostForAgent).ToString()));
                        break;
                    case 5:
                        products.Sort((p1, p2) => int.Parse((p2.MinCostForAgent - p1.MinCostForAgent).ToString()));
                        break;
                }
            }

            if (filterByCB.SelectedIndex >= 0)
            {
                FilterByVariant item = (filterByCB.SelectedItem as FilterByVariant);
                if (item.id != 0)
                {
                    products = products.FindAll(p => p.ProductTypeID == item.id);
                }
            }

            foreach (Product product in products)
            {
                if (!product.Title.ToLower().Contains(searchTB.Text.ToLower()))
                    continue;
                List<String> materialNames = product.ProductMaterial.Select(m => m.Material.Title).ToList();
                List<decimal> materialCosts = product.ProductMaterial.Select(m => m.Material.Cost).ToList();

                LVProduct productLV = new LVProduct(
                    product.Title,
                    product.ProductType.Title,
                    product.ArticleNumber,
                    $"Материалы: {String.Join(", ", materialNames)}",
                    materialCosts.Sum().ToString(),
                    product.Image is null || product.Image == "" ? "\\products\\picture.png" : product.Image,
                    product.ID
                );
                lVProducts.Add(productLV);
            }

            productsLV.ItemsSource = lVProducts.Skip((pageNum-1) * 20).Take(20).ToList();
            int pagesCount = (lVProducts.Count / 20) % 1 > 0 ? lVProducts.Count / 20 + 1 : lVProducts.Count / 20;

            navSP.Children.Clear();
            if (pageNum > 1)
            {
                Button button = new Button();
                button.Margin = new Thickness(0, 0, 5, 0);
                button.Content = "<";
                button.Click += Button_Click;
                navSP.Children.Add(button);
            }

            for (int i = 1; i <= pagesCount; i++)
            {
                Button button = new Button();
                button.Content = i.ToString();
                button.Margin = new Thickness(0, 0, 5, 0);
                button.Click += Button_Click;
                navSP.Children.Add(button);
            }

            if (pageNum < pagesCount)
            {
                Button button = new Button();
                button.Margin = new Thickness(0, 0, 5, 0);
                button.Content = ">";
                button.Click += Button_Click;
                navSP.Children.Add(button);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content.ToString() == "<")
            {
                pageNum -= 1;
            } else if (button.Content.ToString() == ">")
            {
                pageNum += 1;
            } else
            {
                pageNum = int.Parse(button.Content.ToString());
            }
            setProducts();
        }

        public ProductsList()
        {
            InitializeComponent();
            setProducts();

            changePrice.Visibility = Visibility.Collapsed;

            List<FilterByVariant> filterByVariants = new List<FilterByVariant>();
            filterByVariants = filterByVariants.Append(new FilterByVariant(
                0, "Все типы"
            )).ToList();

            foreach (ProductType productType in App.db.ProductType.ToList())
            {
                filterByVariants = filterByVariants.Append(new FilterByVariant(
                    productType.ID,
                    productType.Title
                )).ToList();
            }

            filterByCB.ItemsSource = filterByVariants;
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            setProducts();
        }

        private void sortByCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setProducts();
        }

        private void filterByCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setProducts();
        }

        private void productsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productsLV.SelectedItems.Count > 0)
            {
                changePrice.Visibility = Visibility.Visible;
            } else
            {
                changePrice.Visibility = Visibility.Collapsed;
            }
        }

        private void changePrice_Click(object sender, RoutedEventArgs e)
        {
            List<int> selectedIds = new List<int>();
            foreach (LVProduct prod in productsLV.SelectedItems)
            {
                selectedIds = selectedIds.Append(prod.id).ToList();
            }
            changeProductPricesWindow modalWindow = new changeProductPricesWindow(selectedIds);
            modalWindow.ShowDialog();
            setProducts();
        }
    }
}
