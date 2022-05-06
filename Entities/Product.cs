namespace Entities
{
    public class Product : Entity
    {

        public string name  { get; set; }
        public string description  { get; set; }
        public double price { get; set; }
        public Category category { get; set; }
    }
}