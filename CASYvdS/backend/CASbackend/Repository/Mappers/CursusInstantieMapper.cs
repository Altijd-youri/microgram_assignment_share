using CASbackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CASbackend.Repository.Mappers;

public class CursusInstantieMapper : IEntityTypeConfiguration<CursusInstantie>
{
    public void Configure(EntityTypeBuilder<CursusInstantie> builder)
    {
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.StartDatum)
            .IsRequired();
        builder.HasOne(ci => ci.Cursus);
    }
}