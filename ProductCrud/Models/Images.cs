using System.Text.Json.Serialization;

namespace ProductCrud.Models
{
    public class Images
    {
        public int id { get; set; }
        public string ImageName { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
