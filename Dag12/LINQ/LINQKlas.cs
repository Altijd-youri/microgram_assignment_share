namespace LINQ;

public class LINQKlas
{
    public static List<char> FindWithJ_comperhension(List<string> klas)
    {
        var query =
            from persoon in klas
            where persoon.Contains("J") || persoon.Contains("j")
            select persoon[0];
        return query.ToList();
    }

    public static List<char> FindWithJ_method(List<string> klas)
    {
        var query = 
            klas
                .Where(persoon => persoon.Contains("J") || persoon.Contains("j"))
                .Select(persoon => persoon[0]);
        return query.ToList();
    }

    public static List<int> FindLengthStartingWithMDescending_method(List<string> klas)
    {
        var query =
            klas
                .Where(persoon => persoon.StartsWith("M"))
                .OrderByDescending(persoon => persoon.Length)
                .Select(persoon => persoon.Length);
                
        return query.ToList();
    }

    public static List<int> FindLengthStartingWithMDescending_comperhension(List<string> klas)
    {
        
        var query =
            from persoon in klas
            where persoon.StartsWith("M")
            orderby persoon.Length descending
            select persoon.Length;
                
        return query.ToList();
    }

    public static List<int> CountNameLengthByName_comperhension(List<string> list)
    {
        var query =
            from naam in list
            let naamLength = naam.Length
            orderby naamLength
            group naam by naamLength
            into lengthGroup
            select lengthGroup.Count();
        
        return query.ToList();
    }
    
    public static List<int> CountNameLengthByName_method(List<string> list)
    {
        var query = list
            .OrderBy(naam => naam.Length)
            .GroupBy(naam => naam.Length)
            .Select(grouping => grouping.Count());
        return query.ToList();
    }
    
    public static List<string> NamesShorterThanWithoutLetter_comprehension(List<string> list, char withoutLetter = 'm')
    {
        var query =
            from naam in list
            let maxLenght = (from subNaam in list
                select subNaam.Length).Min()
            orderby naam
            where naam.Length <= maxLenght
            where !naam.Contains(withoutLetter, StringComparison.InvariantCultureIgnoreCase)
            select naam;

        return query.ToList();
    }
    
    public static List<string> NamesShorterThanWithoutLetter_method(List<string> list, char withoutLetter = 'm')
    {
        var query = list
            .Select(naam => naam)
            .OrderBy(naam => naam)
            .Where(naam => naam.Length <= list.Min(naam => naam.Length))
            .Where(naam => !naam.Contains(withoutLetter, StringComparison.InvariantCultureIgnoreCase));

        return query.ToList();
    }
    
}