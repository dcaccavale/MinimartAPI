namespace Core.Infrastructure
{
    public  class StocksResponse
    {
        public int Count { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public Guid ProductId { get; set; }

    }
}