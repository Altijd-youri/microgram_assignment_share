using Microsoft.EntityFrameworkCore;
using OrderBackend.Models;
using OrderBackend.Repository.mapping;

namespace OrderBackend.Repository;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderMapping());
        modelBuilder.ApplyConfiguration(new OrderRowMapping());
        modelBuilder.ApplyConfiguration(new ProductMapping());
    
        base.OnModelCreating(modelBuilder);
    }
}