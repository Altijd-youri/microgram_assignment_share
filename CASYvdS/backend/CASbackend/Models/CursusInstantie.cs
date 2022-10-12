namespace CASbackend.Models;

public class CursusInstantie
{
    public Cursus Cursus { get; set; }
    public DateTime StartDatum { get; }
    
    public string CursusCode { get; }

    public CursusInstantie()
    {
    }

    public CursusInstantie(Cursus cursus, DateTime startDatum)
    {
        Cursus = cursus;
        StartDatum = startDatum;
        CursusCode = cursus.Code;
    }
}
