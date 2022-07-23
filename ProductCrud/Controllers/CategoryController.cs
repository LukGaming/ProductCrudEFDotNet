using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCrud.Dtos;
using ProductCrud.Models;

namespace ProductCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await _context.Categories.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        [HttpDelete]
        public async Task<ActionResult<List<Category>>> Delete(int id)
        {
            _context.Remove(_context.Categories.Single(a => a.Id == id));
            _context.SaveChanges();
            return await _context.Categories.ToListAsync();
        }
        [HttpPut]
        public async Task<ActionResult<Category>> Put(int id, CreateCategoryDto request)
        {

            var category = await _context.Categories.FindAsync(id);
            category.CategoryName = request.CategoryName;
            _context.Update(category);
            _context.SaveChanges();
            return Ok(category);
        }
    }
}
