using System.Globalization;

namespace CASwebsite.Models;

public class Weeknumber
{
    public int Week { get; set;  }
    public int Jaar { get; set;  }
    public int WeekInJaar { get; set;  }

    public Weeknumber()
    {
    }

    public Weeknumber(int week, int jaar)
    {
        Week = week;
        Jaar = jaar;
        WeekInJaar = ISOWeek.GetWeeksInYear(jaar);
        if (Week > WeekInJaar)
        {
            throw new ArgumentOutOfRangeException(nameof(Week), week, "Weeknummer bestaat niet in gegeven jaar.");
        }
    }
    
    public override string ToString() => $"{Week}, {Jaar}";
}