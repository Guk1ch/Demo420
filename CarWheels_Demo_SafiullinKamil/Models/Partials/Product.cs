using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWheels_Demo_SafiullinKamil.Models
{
    public partial class Product
    {
        public string NewImagePath
        {
            get
            {
                if (Image != null)
                {
                    return $"/Assets{Image}";
                }
                else
                {
                    return $"/Assets/Images/picture.png";
                }

            }
        }

        public string TypeTitle
        {
            get
            {
                return $"{ProductType.Title} | {Title}";
            }
        }
    }
}
