using System.Globalization;

namespace CASwebsite.Models;

public class CursusLijst
{
    public Weeknumber Weeknummer { get; set; }
    
    public Weeknumber VorigeWeek { get; set; }
    
    public Weeknumber VolgendeWeek { get; set; }
    public IEnumerable<CursusInstantie> CursusInstanties { get; set; }

    public CursusLijst()
    {
    }

    public CursusLijst(Weeknumber weeknummer, IEnumerable<CursusInstantie> cursusInstanties)
    {
        DateTime mondayOfCurrentWeek = ISOWeek.ToDateTime(weeknummer.Jaar, weeknummer.Week, DayOfWeek.Monday);
        var lastWeek = mondayOfCurrentWeek.AddDays(-7);
        var nextWeek = mondayOfCurrentWeek.AddDays(7);
        
        VorigeWeek = new Weeknumber(ISOWeek.GetWeekOfYear(lastWeek), ISOWeek.GetYear(lastWeek));
        VolgendeWeek = new Weeknumber(ISOWeek.GetWeekOfYear(nextWeek), ISOWeek.GetYear(nextWeek));
        Weeknummer = weeknummer;
        CursusInstanties = cursusInstanties;
    }
}