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
}