namespace Dag09.Personen;

public class Werknemer : Persoon
{
    public decimal Salaris { get; private set; }
    public Werknemer(string naam, int leeftijd, decimal salaris) 
        : base(naam, leeftijd)
    {
        Salaris = salaris;
    }

    public override void Verjaar()
    {
        Salaris *= 1.01M;
        base.Verjaar();
    }
    
}