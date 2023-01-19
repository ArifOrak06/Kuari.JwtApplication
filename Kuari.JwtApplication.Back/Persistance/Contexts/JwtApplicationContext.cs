using Kuari.JwtApplication.Back.Core.Domain;
using Kuari.JwtApplication.Back.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kuari.JwtApplication.Back.Persistance.Contexts
{
    public class JwtApplicationContext : DbContext
    {
        public JwtApplicationContext(DbContextOptions<JwtApplicationContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
