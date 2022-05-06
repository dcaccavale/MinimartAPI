using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Voucher :Entity
    {
        public RangeDate rangeDate { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        public string code { get; set; }


    }
    internal class VoucherProduct : Voucher
    {
        public IList<Product> apllyProduct { get; set; }
        
    }
    internal class VoucherCategory : Voucher
    {
        public IList<Category> apllyCategories { get; set; }
        public IList<Product> exceptProduct { get; set; }
    }
}
