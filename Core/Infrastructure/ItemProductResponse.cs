using System;

namespace Core.Infrastructure
{ 
    public class ItemProductResponse
    {
        public Guid storeId { get; set; }
        public Guid productId { get; set; }
        public Guid cartId { get; set; }
        public int Amound { get; set; }
        public double Price { get; set; }
        public double Pay { get; set; }

    }
}