namespace Entities
{
    public class StockProduct : Entity
    {
        public Store store { get; set; }
        public Product product { get; set; }
        public int amount { get; set; }
    }
}