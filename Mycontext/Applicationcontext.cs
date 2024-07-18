using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WideBot.Configurations;
using WideBot.Models;

namespace WideBot.Mycontext
{
    public class Applicationcontext:IdentityDbContext<ApplicationUser>
    {
        public Applicationcontext()
        {
            
        }
        public Applicationcontext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new CartConfigurations());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; } 
        public DbSet<Cart> carts { get; set; } 
    }
}
