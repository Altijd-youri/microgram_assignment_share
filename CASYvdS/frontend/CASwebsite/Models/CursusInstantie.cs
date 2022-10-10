namespace CASwebsite.Models;

public class CursusInstantie
{
    public long Id { get; set; }
    public Cursus Cursus { get; set; }
    public DateTime StartDatum { get; set; }

    public CursusInstantie(Cursus cursus, DateTime startDatum)
    {
        Cursus = cursus;
        StartDatum = startDatum;
    }
}