using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCrud.Dtos;
using ProductCrud.Models;

namespace ProductCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Product>>> Get()
        {
           return await _context.Products.Include(i => i.Category).Include(i => i.Images).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Post(CreateProductDto request)
        {
            var category = await _context.Categories.FindAsync(request.CategoryId);
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value,
                Category = category
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpDelete]
        public async Task<ActionResult<IList<Product>>> Delete(int id)
        {

            _context.Remove(_context.Products.Single(a => a.Id == id));
            _context.SaveChanges();
            return await _context.Products.ToListAsync();
        }
        [HttpPut]
        public async Task<ActionResult<Product>> Put(int id, CreateProductDto request)
        {
            
            Product product = await _context.Products.FindAsync(id);
            Category category = await _context.Categories.FindAsync(request.CategoryId);
            product.Name = request.Name;
            product.Description = request.Description;
            product.Value = request.Value;
            product.Category = category;
            _context.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
