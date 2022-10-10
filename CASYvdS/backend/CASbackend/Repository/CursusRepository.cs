using System.Globalization;
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

    public IEnumerable<CursusInstantie> GetAllCursusInstanties(int weeknummer)
    {
        using var context = new CursusContext(_options);
        return context.CursusInstanties
            .Include(ci => ci.Cursus)
            .ToList()
            .Where(ci => GetWeeknummer(ci.StartDatum) == weeknummer)
            .ToList();
    }
    
    private static int GetWeeknummer(DateTime date)
    {
        Calendar cal = new GregorianCalendar();
        DayOfWeek firstDay = DayOfWeek.Monday;
        CalendarWeekRule rule = CalendarWeekRule.FirstFourDayWeek;
        var weeknummer = cal.GetWeekOfYear(date, rule, firstDay);
        return weeknummer;
    }
}