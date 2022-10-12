namespace CASbackend.Models;

public class Cursus
{
    public string Code { get; }
    public string Titel { get; }
    public int Duur { get; }

    public Cursus()
    {
    }

    public Cursus(string code, string titel, int duur)
    {
        Code = code;
        Titel = titel;
        Duur = duur;
    }
}