using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practiceAPI4.Model;

namespace practiceAPI4.Controllers
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
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found");
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, Product request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return BadRequest("product not found");
            product.name = request.name;
            product.description = request.description;
            product.price = request.price;
            

            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("product deleted");
        }
    }
}
