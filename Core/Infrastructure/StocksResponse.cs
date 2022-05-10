namespace Core.Infrastructure
{
    public  class StocksResponse
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public Guid ProductId { get; set; }

    }
}