using SochnevDemoApp.Models;
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

namespace SochnevDemoApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        public AddEditProductWindow(Product product)
        {
            InitializeComponent();
            if(product.ID == 0)
            {
                Title = "Добавление продукции";
            }
            else
            {
                Title = "Редактирование продукции";
            }
        }
    }
}
