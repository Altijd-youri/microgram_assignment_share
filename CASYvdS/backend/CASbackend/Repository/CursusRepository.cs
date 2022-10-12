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

    public FileUpload CreateCursusInstanties(IEnumerable<CursusInstantie> instanties)
    {
        using var context = new CursusContext(_options);
        var status = new FileUpload();
        List<Cursus> insertedCursussen = new ();
        List<CursusInstantie> insertedInstanties = new ();
        
        foreach (var instantie in instanties)
        {
            bool PrimaryKeyCheckOnInstantie(CursusInstantie a) => a.StartDatum == instantie.StartDatum && a.CursusCode == instantie.CursusCode;
            bool PrimaryKeyCheckOnCursus(Cursus a) => a.Code == instantie.CursusCode;
            
            var duplicate = 
                context.CursusInstanties.Any(PrimaryKeyCheckOnInstantie) ||
                insertedInstanties.Any(PrimaryKeyCheckOnInstantie);
            if (duplicate)
            {
                status.Duplicates++;
            } 
            else
            {
                var sourceOfTruthCursus = context.Cursussen.SingleOrDefault(PrimaryKeyCheckOnCursus);
                if (sourceOfTruthCursus == null)
                {
                    sourceOfTruthCursus = insertedCursussen.SingleOrDefault(PrimaryKeyCheckOnCursus);
                    if (sourceOfTruthCursus == null)
                    {
                        sourceOfTruthCursus = instantie.Cursus;
                        insertedCursussen.Add(sourceOfTruthCursus);
                        status.CursusInserts++;
                        insertedInstanties.Add(instantie);
                    }
                }
                
                instantie.Cursus = sourceOfTruthCursus;
                context.CursusInstanties.Add(instantie);
                status.InstantieInserts++;
            }
        }
        context.SaveChanges();
        return status;
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