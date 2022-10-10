namespace CASbackend.Models;

public class Cursus
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string Naam { get; set; }
    public int Duur { get; set; }

    public Cursus()
    {
    }

    public Cursus(string code, string naam, int duur)
    {
        Code = code;
        Naam = naam;
        Duur = duur;
    }
    public Cursus(long id, string code, string naam, int duur)
    {
        Id = id;
        Code = code;
        Naam = naam;
        Duur = duur;
    }
}