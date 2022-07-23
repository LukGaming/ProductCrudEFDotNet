using Microsoft.EntityFrameworkCore;
using ProductCrud.Models;
using System.Data;

namespace ProductCrud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}
