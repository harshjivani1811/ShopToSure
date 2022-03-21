using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practiceAPI4.Model;

namespace practiceAPI4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        public AdminController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAll()
        {
            return Ok(await _context.Admin.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Admin>>> Add(Admin admin)
        {
            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();

            return Ok(await _context.Admin.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> Get(int id)
        {
            var admin = await _context.Admin.FindAsync(id);
            if(admin == null)
                return NotFound("Admin not found");
            return Ok(admin);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Admin>> Put(int id, Admin request)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
                return BadRequest("Admin not found");
            admin.firstName = request.firstName;
            admin.lastName = request.lastName;
            admin.email = request.email;
            admin.password = request.password;
            admin.phoneNumber = request.phoneNumber;

            await _context.SaveChangesAsync();
            return Ok(admin);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> Delete(int id)
        {
            var admin = await _context.Admin.FindAsync(id);
            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();

            return Ok("Admin deleted");
        }

    }
}
