namespace Dag09.Personen;

public delegate void LeeftijdChangedEventHandler(object sender, LeeftijdChangedEventArgs args);

public class LeeftijdChangedEventArgs : EventArgs
{
    public readonly int Leeftijd;
    public readonly int OudeLeeftijd;
    public readonly String Naam;

    public LeeftijdChangedEventArgs(int leeftijd, int oudeLeeftijd, string naam)
    {
        Leeftijd = leeftijd;
        OudeLeeftijd = oudeLeeftijd;
        Naam = naam;
    }
}