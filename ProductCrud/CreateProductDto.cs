namespace ProductCrud
{
    public class CreateProductDto
    {
        public int ?Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; } = 0;
        public int CategoryId { get; set; } = 1;

        public static implicit operator EntityState(CreateProductDto v)
        {
            throw new NotImplementedException();
        }
    }
}
