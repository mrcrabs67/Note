using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Note.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Notes> Notes { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
