using System;

namespace Minimart_API.ViewModel
{
    public class ItemProductRequest
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public string? VoucherCode { get; set; }
        
    }
}
