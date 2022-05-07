using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Discount
{
    public class PercentageSecundDiscount : PercentageDiscount 
    {
        /// <summary>
        /// returns the maximum number of products to apply the discount
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        protected override int getMaxquantityProducto(int quantity)
        {
            double auxQuantity = quantity / 2;
            double auxLimitQuantity = Limit / 2;
            return   Limit == 0? (int)Math.Floor(auxQuantity) :  quantity <= Limit ? (int)Math.Floor(auxQuantity) : (int) Math.Floor(auxLimitQuantity);
        }

    }
}
