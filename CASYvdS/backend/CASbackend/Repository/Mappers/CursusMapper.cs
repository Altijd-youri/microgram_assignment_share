using CASbackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CASbackend.Repository.Mappers;

public class CursusMapper : IEntityTypeConfiguration<Cursus>
{
    public void Configure(EntityTypeBuilder<Cursus> builder)
    {
        builder.HasKey(c => c.Code);
        builder.Property(c => c.Code)
            .IsRequired();
        builder.Property(c => c.Duur)
            .IsRequired();
        builder.Property(c => c.Titel)
            .IsRequired();
    }
}