namespace ProductCrud.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; } = 0;
        public Category Category { get; set; }
        public List<Images> Images { get; set; }

    }
}
