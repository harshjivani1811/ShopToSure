using Microsoft.EntityFrameworkCore;
using practiceAPI4.Model;

namespace practiceAPI4.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Admin> Admin { get; set; }
    }
}
