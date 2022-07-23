namespace ProductCrud.Dtos
{
    public class CreateCategoryDto
    {
        public int? Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
