namespace Entities
{
    public class ProductDiscountToApply: Entity
    {
        public Product Product { get; set; }
        public  Voucher Voucher { get; set; }
    }
}