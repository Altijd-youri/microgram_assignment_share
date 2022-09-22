namespace Dag09.Personen;

public class Werknemer : Persoon
{
    public decimal Salaris { get; private set; }
    public Werknemer(string naam, int leeftijd, decimal salaris) 
        : base(naam, leeftijd)
    {
        Salaris = salaris;
    }
    private decimal VerhoogSalaris(int aantalJaren)
    {
        if (aantalJaren > 0)
        {
            aantalJaren--;
            Salaris = Decimal.Round(Salaris * 1.01M, 2);
            return VerhoogSalaris(aantalJaren);
        }
        return Salaris;
    }

    protected override void OnLeeftijdChanged(LeeftijdChangedEventArgs e)
    {
        int change = e.Leeftijd - e.OudeLeeftijd;
        VerhoogSalaris(change);
        base.OnLeeftijdChanged(e);
    }
}