using System.Text.RegularExpressions;

namespace Dag08.PatternMatching;

public class PatternMatcher
{
    private Regex pattern;
    
    public PatternMatcher()
    {
        pattern = new Regex(@"^-?\d+\.\d{2}$");
    }

    public bool isNummer(string nummer) => pattern.IsMatch(nummer);

}