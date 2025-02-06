using Demo_Podgotovka_Mukachev.DB;
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

namespace Demo_Podgotovka_Mukachev.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductCRUDPage.xaml
    /// </summary>
    public partial class ProductCRUDPage : Page
    {

        public ProductCRUDPage()
        {
            InitializeComponent();

        }
        public ProductCRUDPage(Product product)
        {
            InitializeComponent();

        }
    }
}
