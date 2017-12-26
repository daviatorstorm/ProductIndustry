using Microsoft.EntityFrameworkCore;

namespace SIENN.DbAccess.Models
{
    public class SIENNDbContext : DbContext
    {
        public SIENNDbContext(DbContextOptions<SIENNDbContext> opts)
            : base(opts)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductUnit> Units { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductType> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(x => new { x.CategoryCode, x.ProductCode });

            base.OnModelCreating(modelBuilder);
        }
    }
}
