using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagdieva_Srez.DB
{
    public partial class Product
    {
        public decimal Cost
        {
            get
            {
                return ProductMaterial == null ? 0 : ProductMaterial.Where(i => i.MaterialID == i.Material.ID && i.ProductID == i.Product.ID).Sum(pm => pm.Material.Cost * (pm.Count.HasValue ? (decimal)pm.Count.Value : 0));
            }
        }
    }
}
