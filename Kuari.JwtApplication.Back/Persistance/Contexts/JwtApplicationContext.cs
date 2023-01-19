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

        public DbSet<Product> Products => this.Set<Product>();
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
