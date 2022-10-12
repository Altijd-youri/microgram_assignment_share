namespace CASbackend.Models;

public class CursusInstantieBuilder
{
    private string? Code { get; set;  }
    private string? Titel { get; set; }
    private int Duur { get; set; }
    private DateTime StartDatum { get; set; }

    private bool CanBuild() => Code != null && Titel != null && Duur != null && StartDatum != null;

    public static CursusInstantieBuilder Get()
    {
        return new CursusInstantieBuilder();
    }

    private CursusInstantieBuilder()
    {
        
    }

    public CursusInstantie Build()
    {
        if (!CanBuild()) throw new ArgumentException("Can't build Cursus instantie, specify all required properties");
        return new CursusInstantie(
            new Cursus(Code!, Titel!, Duur),
            StartDatum
        );
    }

    public CursusInstantieBuilder AddTitel(string titel)
    {
        Titel = titel;
        return this;
    }
    
    public CursusInstantieBuilder AddDuur(int duur)
    {
        Duur = duur;
        return this;
    }
    
    public CursusInstantieBuilder AddCursusCode(string cursuscode)
    {
        Code = cursuscode;
        return this;
    }
    
    public CursusInstantieBuilder AddStartDatum(DateTime startDatum)
    {
        StartDatum = startDatum;
        return this;
    }
}