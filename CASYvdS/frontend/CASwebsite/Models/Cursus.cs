namespace CASwebsite.Models;

public class Cursus
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string Naam { get; set; }
    public int Duur { get; set; }

    public Cursus(string code, string naam, int duur)
    {
        Code = code;
        Naam = naam;
        Duur = duur;
    }
}