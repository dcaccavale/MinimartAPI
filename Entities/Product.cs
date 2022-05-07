namespace Entities
{
    public class Product : Entity
    {

        public string Name  { get; set; }
        public string Description  { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}