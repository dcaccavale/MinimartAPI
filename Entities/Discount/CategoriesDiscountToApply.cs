namespace Entities
{
    public class CategoriesDiscountToApply:Entity
    {
        public Category Category { get; set; }
        public VoucherCategory Voucher { get; set; }
    }
}