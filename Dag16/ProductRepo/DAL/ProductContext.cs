using Microsoft.EntityFrameworkCore;
using ProductRepo.DAL.Mappings;

namespace ProductRepo.DAL;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMapping());
        modelBuilder.ApplyConfiguration(new CategoryMapping());

        base.OnModelCreating(modelBuilder);
    }
}