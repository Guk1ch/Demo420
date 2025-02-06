using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SochnevDemoApp.Models
{
    public partial class Product
    {
        public double TotalCost
        {
            get
            {
                double result = 0;
                foreach (var item in ProductMaterial)
                {
                    result += (double)item.Material.Cost * (double)item.Count;
                }
                return result;
            }
            set
            {

            }
        }
        public string BindingPath
        {
            get
            {
                return Image == "" ? "/Resources/picture.png" : Image;
            }
            set
            {

            }
        }
        public List<string> MaterialList
        {
            get
            {
                List<string> result = new List<string>
                {
                    "Материалы:"
                };
                foreach(var item in ProductMaterial)
                {
                    result.Add($"{item.Material.Title},");
                }
                string last = result.Last().Replace(",", "");
                result.RemoveAt(result.Count - 1);
                result.Add(last);
                return result;
            }
            set
            {

            }
        }
        public string LastMonthSaleColor
        {
            get
            {
                return ProductSale.FirstOrDefault(x => x.SaleDate.Month == DateTime.Now.Month) == null ? "" : "#D3D3D3";
            }
            set
            {

            }
        }
    }
}
