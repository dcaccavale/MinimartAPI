namespace Entities
{
    public class ExceptedDiscountProduct : Entity
    {
        public Product Product { get; set; }
        public Voucher Voucher { get; set; }
    }
}