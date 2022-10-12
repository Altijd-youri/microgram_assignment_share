using System.Globalization;

namespace CASwebsite.Models;

public class CursusLijst
{
    public int Weeknummer { get; set; }
    
    public int VorigeWeek { get; set; }
    
    public int VolgendeWeek { get; set; }
    public IEnumerable<CursusInstantie> CursusInstanties { get; set; }

    public CursusLijst()
    {
    }

    public CursusLijst(int weeknummer, IEnumerable<CursusInstantie> cursusInstanties)
    {
        DateTime mondayOfCurrentWeek = ISOWeek.ToDateTime(DateTime.Today.Year, weeknummer, DayOfWeek.Monday);
        VorigeWeek = ISOWeek.GetWeekOfYear(mondayOfCurrentWeek.AddDays(-7));
        VolgendeWeek = ISOWeek.GetWeekOfYear(mondayOfCurrentWeek.AddDays(7));
        Weeknummer = weeknummer;
        CursusInstanties = cursusInstanties;
    }
}