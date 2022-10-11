namespace CASbackend.Models;

public class Cursus
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string Titel { get; set; }
    public int Duur { get; set; }

    public Cursus()
    {
    }

    public Cursus(string code, string titel, int duur)
    {
        Code = code;
        Titel = titel;
        Duur = duur;
    }
    public Cursus(long id, string code, string titel, int duur)
    {
        Id = id;
        Code = code;
        Titel = titel;
        Duur = duur;
    }
}