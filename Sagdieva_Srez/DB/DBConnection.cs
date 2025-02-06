using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagdieva_Srez.DB
{
    internal class DBConnection
    {
        public static Sagdieva_DB_SrezEntities srez = new Sagdieva_DB_SrezEntities();
        public static Product editProduct;
    }
}
