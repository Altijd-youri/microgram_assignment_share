using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderBackend.Models;

namespace OrderBackend.Repository.mapping;

public class OrderRowMapping : IEntityTypeConfiguration<OrderRow>
{
    public void Configure(EntityTypeBuilder<OrderRow> builder)
    {
        builder.HasKey(or => or.Id);
        builder.Property(or => or.Aantal);
        builder.HasOne(or => or.Product);
    }
}