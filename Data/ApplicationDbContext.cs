using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteSafe4.Models;

namespace SiteSafe4.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Other DbSets
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<SupervisorDevice> SupervisorDevices { get; set; }


        // You no longer need DbSet<User> because AppUser is handled by Identity
    }
}
