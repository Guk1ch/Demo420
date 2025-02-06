using Demo_Podgotovka_Mukachev.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Demo_Podgotovka_Mukachev
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static vosmerka_demo_MukachevEntities db = new vosmerka_demo_MukachevEntities(); 
    }
}
