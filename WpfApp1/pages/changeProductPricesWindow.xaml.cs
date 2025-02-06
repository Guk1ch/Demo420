using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.pages
{
    /// <summary>
    /// Логика взаимодействия для changeProductPricesWindow.xaml
    /// </summary>
    public partial class changeProductPricesWindow : Window
    {
        public List<int> productIds;
        public changeProductPricesWindow(List<int> productIds)
        {
            InitializeComponent();
            this.productIds = productIds;

            newPriceTB.Text = Decimal.ToInt64(App.db.Product.ToList().Select(p => p.MinCostForAgent).ToList().Average()).ToString();
        }

        private void newPriceTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Product.Where(p => productIds.Contains(p.ID)).ToList().ForEach(p => 
                p.MinCostForAgent = int.Parse(newPriceTB.Text));
            App.db.SaveChanges();
            this.Close();
        }
    }
}
