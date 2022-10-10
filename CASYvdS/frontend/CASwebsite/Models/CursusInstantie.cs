namespace CASwebsite.Models;

public class CursusInstantie
{
    public long Id { get; set; }
    public Cursus Cursus { get; set; }
    public DateOnly StartDatum { get; set; }

    public CursusInstantie(Cursus cursus, DateOnly startDatum)
    {
        Cursus = cursus;
        StartDatum = startDatum;
    }
}