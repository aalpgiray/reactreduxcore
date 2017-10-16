using Microsoft.EntityFrameworkCore;

namespace SecretService.Data
{
    public class SecretServiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Route> Routes { get; set; }

        public SecretServiceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new GeometryConfig());
            modelBuilder.ApplyConfiguration(new RouteConfig());
        }
    }
}