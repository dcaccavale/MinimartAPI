using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class ItemProduct:Entity
    {
        public int Quantity { get; set; }
        public double PriceUnit { get; set; }
        public Product? Product { get; set; }
        public double TotalDiscount { get; set; }

    }
}
