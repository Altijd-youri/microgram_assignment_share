using CASbackend.Models;
using CASbackend.Repository.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CASbackend.Repository;

public class CursusContext : DbContext
{
    public CursusContext(DbContextOptions<CursusContext> options) : base(options)
    {
    }
    
    public DbSet<CursusInstantie> CursusInstanties { get; set; }
    public DbSet<Cursus> Cursussen { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CursusInstantieMapper());
        modelBuilder.ApplyConfiguration(new CursusMapper());
        base.OnModelCreating(modelBuilder);
    }
}