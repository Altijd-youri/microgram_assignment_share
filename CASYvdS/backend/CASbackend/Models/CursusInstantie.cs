namespace CASbackend.Models;

public class CursusInstantie
{
    public long Id { get; set; }
    public Cursus Cursus { get; set; }
    public DateTime StartDatum { get; set; }

    public CursusInstantie()
    {
    }

    public CursusInstantie(Cursus cursus, DateTime startDatum)
    {
        Cursus = cursus;
        StartDatum = startDatum;
    }
    public CursusInstantie(long id, Cursus cursus, DateTime startDatum)
    {
        Id = id;
        Cursus = cursus;
        StartDatum = startDatum;
    }
}
