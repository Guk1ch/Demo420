using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Vosmerka8_Demo_Safiullin.DB;

namespace Vosmerka8_Demo_Safiullin
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static VosmerkaEntities vosmerka = new VosmerkaEntities();
    }
}
