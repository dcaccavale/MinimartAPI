using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class AddProductCart:Entity
    {
        public int quantity { get; set; }
        public double priceUnit { get; set; }
            
        public Product product { get; set; }


    }
}
