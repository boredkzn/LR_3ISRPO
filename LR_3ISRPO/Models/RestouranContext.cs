using Microsoft.EntityFrameworkCore;

namespace LR_3ISRPO.Models
{
    public class RestouranContext : DbContext
    {
        public DbSet<Restouran> MainTable { get; set; }
        public RestouranContext(DbContextOptions<RestouranContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
