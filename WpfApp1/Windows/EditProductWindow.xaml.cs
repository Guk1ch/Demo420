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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public Product Product { get; private set; }

        public EditProductWindow(Product product)
        {
            InitializeComponent();

            this.Product = product;
        }


        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.DB.Product.Remove(Product);
            DBConnection.DB.SaveChanges();
            

            Close();
        }
    }
}
