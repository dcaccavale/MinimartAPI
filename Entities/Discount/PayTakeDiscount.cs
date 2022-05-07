using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Discount
{
    public class PayTakeDiscount : Entity, IDiscount
    {
        public int PayCount { get; set; }
        public int TakeCount { get; set; }

        /// <summary>
        /// returns the maximum number of products to apply the discount
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        protected virtual int GetMaxquantityProducto(int quantity)
        {

            double auxQuantity = quantity / TakeCount;
            return   (int)Math.Floor(auxQuantity) ;

        }

        public double CalculateDiscount(ItemProduct addProductCart)
        {
            return addProductCart.Quantity > PayCount ?  addProductCart.PriceUnit * (TakeCount - PayCount)  * GetMaxquantityProducto(addProductCart.Quantity)  : 0;

        }
    }
}

