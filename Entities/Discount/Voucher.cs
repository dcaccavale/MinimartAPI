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

        public string DaysOfWeek { get; set; }

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
        /// Store to apply voucher
        /// </summary>
        public Store Store { get; set; }

        /// <summary>
        /// Validate a voucher in a range of dates and day of the week 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// 
        public bool Validate(DateTime dateToValidate, Store storeToValidate) {

                 //Validate store
            return storeToValidate.Id == Store.Id &&
                //Validate date in range 
                RangeDate.DateInRange(dateToValidate) &&
                //dayOfWeek.Length == 0 applies every day of the week
                (DaysOfWeek.Length == 0 || dateToValidate.DayOfWeek.ToString().Contains(DaysOfWeek));
      
        }
        public double CalculateDiscount(ItemProduct product, DateTime dateTimeToApply )
        {
            if (!Validate(dateTimeToApply, this.Store)) return 0;
            return this.Discount.CalculateDiscount(product);

        }


    }
    /// <summary>
    /// A voucher to apply for products
    /// </summary>
    public class VoucherProduct : Voucher
    {
        /// <summary>
        /// Products to apply 
        /// </summary>
        public IList<ProductDiscountToApply> ProductToApply { get; set; }
        
    }
    /// <summary>
    /// a voucher to apply for categories product
    /// </summary>
    public class VoucherCategory : Voucher
    {
        /// <summary>
        /// Categories product to apply
        /// </summary>
        public IList<CategoriesDiscountToApply> CategoriesToApply { get; set; }

        /// <summary>
        /// List of excepted products
        /// </summary>
        public IList<ExceptedDiscountProduct> ExceptedDiscountProduct { get; set; }
    }
}
