using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Discount
{
    public class PercentageDiscount : GenericDiscount
    {

        /// <summary>
        /// Percentaje to apply, max value 100
        /// </summary>
        public double Percentage { get; set; }

        /// <summary>
        /// Auxiliary Calculation to apply percentage
        /// </summary>
        /// <returns></returns>
      

        /// <summary>
        /// returns the maximum number of products to apply the discount
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        protected virtual int  getMaxquantityProducto(int quantity) {

            return Limit == 0 ? quantity : quantity <= Limit ? quantity : Limit;
        }

        /// <summary>
        /// Calculate discount
        /// </summary>
        /// <param name="addProductCart"></param>
        /// <returns></returns>
        public override double CalculateDiscount(ItemProduct addProductCart)
        {
           return addProductCart.PriceUnit * this.getMaxquantityProducto(addProductCart.Quantity) * (Percentage /100)  ;
        }
    }
}
