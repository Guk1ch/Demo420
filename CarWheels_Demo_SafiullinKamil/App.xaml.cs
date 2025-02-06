using CarWheels_Demo_SafiullinKamil.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarWheels_Demo_SafiullinKamil
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CarWheels_Demo_420_KamilEntities db = new CarWheels_Demo_420_KamilEntities();
        public static Product selectedProduct { get; set; }
    }
}
