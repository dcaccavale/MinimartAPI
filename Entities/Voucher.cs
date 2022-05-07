using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// A promotional code is a code offered by stores to customers who can use it to receive a discounted price when buying products.
    /// </summary>
    public class  Voucher :Entity
    {
        /// <summary>
        /// Date range to apply a voucher
        /// </summary>
        public RangeDate RangeDate { get; set; }
        /// <summary>
        /// Day of week to apply a voucher
        /// </summary>
         [NotMapped]
        public DayOfWeek[] DayOfWeek { get; set; }

        /// <summary>
        /// Code to us a voucher 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Date range to apply a voucher
        /// </summary>
        [NotMapped] 
        public IDiscount Discount { get; set; }

        /// <summary>
        /// Validate a voucher in a range of dates and day of the week
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool validate(DateTime date) {

            //dayOfWeek.Length == 0 applies every day of the week
            return RangeDate.DateInRange(date) && ( DayOfWeek.Length == 0 || DayOfWeek.Contains(date.DayOfWeek));
      
        }

    }
    /// <summary>
    /// A voucher to apply for products
    /// </summary>
    internal class VoucherProduct : Voucher
    {
        /// <summary>
        /// Products to apply 
        /// </summary>
        public IList<Product> ProductToApply { get; set; }
        
    }
    /// <summary>
    /// a voucher to apply for categories product
    /// </summary>
    internal class VoucherCategory : Voucher
    {
        /// <summary>
        /// Categories product to apply
        /// </summary>
        public IList<Category> CategoriesToApply { get; set; }

        /// <summary>
        /// List of excepted products
        /// </summary>
        public IList<Product> ProductExcept { get; set; }
    }
}
