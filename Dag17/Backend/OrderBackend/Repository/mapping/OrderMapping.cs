using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderBackend.Models;

namespace OrderBackend.Repository.mapping;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Ordernummer);
        builder.Property(o => o.Datum)
            .IsRequired();
        builder.HasMany(o => o.OrderRows);
    }
}