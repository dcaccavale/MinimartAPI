using System;

namespace Core.Infrastructure
{ 
    public class ItemProductResponse
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountTotal { get; set; }
        public double AmoundTotal { get; set; }
        public double AmoundTotalWhitDiscount { get; set; }
        public string  ProductName { get; set; }

    }
}