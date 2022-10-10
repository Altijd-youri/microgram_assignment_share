using Microsoft.EntityFrameworkCore;

namespace CASbackend.Repository;

public class CursusContext : DbContext, ICursusContext
{
    public CursusContext(DbContextOptions<CursusContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}