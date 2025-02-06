using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fayzullina_Elvina_Rafaelevna.Models
{
    public partial class Product
    {
        
        public string DisplayImage
        {
            get
            {
                return string.IsNullOrEmpty(Image) ? "\\products\\picture.png" : Image;
            }
        }
    }
}
