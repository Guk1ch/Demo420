using Demo_Akifev_420_P.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Demo_Akifev_420_P
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Demo_DB_Akifev_420_PEntities db = new Demo_DB_Akifev_420_PEntities();
    }
}
