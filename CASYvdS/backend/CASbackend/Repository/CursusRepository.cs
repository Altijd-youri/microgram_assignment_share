using CASbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CASbackend.Repository;

public class CursusRepository : ICursusRepository
{
    private readonly DbContextOptions<CursusContext> _options;
    
    public CursusRepository(DbContextOptions<CursusContext> options)
    {
        _options = options;
    }

    public IEnumerable<CursusInstantie> GetAllCursusInstanties()
    {
        using var context = new CursusContext(_options);
        return context.CursusInstanties
            .Include(ci => ci.Cursus)
            .ToList();
    }
}