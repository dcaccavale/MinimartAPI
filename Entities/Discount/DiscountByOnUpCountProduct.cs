using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Discount
{
    /// <summary>
    /// Discount aplly to product between 
    /// </summary>
    internal class DiscountByOnUpCountProduct :  Entity
    {
        public int count { get; set; }
        public decimal percentage { get; set; }

    }
}
