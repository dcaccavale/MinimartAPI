using System;

namespace Minimart_API.ViewModel
{
    public class ItemProductRequest
    {
            public Guid cartId { get; set; }
            public int Amound { get; set; }
        public Guid productId { get; set; }
        
    }
}
