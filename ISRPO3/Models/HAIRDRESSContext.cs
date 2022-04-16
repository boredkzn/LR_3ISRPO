
using ISRPOLR3.Models;
using Microsoft.EntityFrameworkCore;

namespace ISRPOLR3.Models
{
    public class HAIRDRESSContext : DbContext
    {
        public DbSet<HAIRDRESS> Main { get; set; }
        public HAIRDRESSContext(DbContextOptions<HAIRDRESSContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
