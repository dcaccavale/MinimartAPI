using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cart: Entity
    {
        public IList<AddProductCart>? ProductsAdd { get; set; }
        public string? Client { get; set; }

        
    }
}
