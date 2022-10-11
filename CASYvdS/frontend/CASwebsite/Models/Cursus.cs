namespace CASwebsite.Models;

public class Cursus
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string Titel { get; set; }
    public int Duur { get; set; }

    public Cursus(string code, string titel, int duur)
    {
        Code = code;
        Titel = titel;
        Duur = duur;
    }
}