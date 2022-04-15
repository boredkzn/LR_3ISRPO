using ISRPO3.Models;
using Microsoft.EntityFrameworkCore;

namespace ISRPO3.Models
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
