namespace ProductCrud.Requests
{
    public class ImagesRequest
    {
        public List<FormFile> Images { get; set; } = new List<FormFile>();
        public int ProductId { get; set; } = 0;

    }
}
